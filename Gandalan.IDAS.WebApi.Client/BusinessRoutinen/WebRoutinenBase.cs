// *****************************************************************************
// Gandalan GmbH & Co. KG - (c) 2023
// *****************************************************************************
// Middleware//Gandalan.IDAS.WebApi.Client//WebRoutinenBase.cs
// Created: 27.01.2016
// Edit: phil - 31.05.2023 11:57
// *****************************************************************************

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Logging;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.Client.Exceptions;
using Gandalan.IDAS.WebApi.Client.RateLimiting;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.Client.Util;
using Gandalan.IDAS.WebApi.DTO;

using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client;

public class WebRoutinenBase
{
    #region Felder

    public IWebApiConfig Settings;
    private readonly IWebApiConfig _originalSettings;
    public bool IsJwt;
    private RESTRoutinen _restRoutinen;
    private const string RelativeDateTimePattern = @"\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d+)?([+-]\d{2}:\d{2})";

    #endregion

    #region Eigenschaften

    public UserAuthTokenDTO AuthToken { get; set; }
    public string Status { get; private set; }
    public bool IgnoreOnErrorOccured { get; set; }
    public string JwtToken { get; set; }

    #endregion

    /// <summary>
    /// Custom handler for exceptions.
    /// </summary>
    /// <returns><see langword="true"/> if the exception was handled - <see langword="false"/> if the exception is not handled</returns>
    public delegate bool ExceptionHandler(Exception ex);

    /// <summary>
    /// Used to register custom handlers to catch Exceptions thrown by <see cref="WebRoutinenBase"/>
    /// </summary>
    public static event ExceptionHandler CustomExceptionHandler;

    public delegate void ErrorOccuredEventHandler(object sender, ApiErrorArgs e);

    public static event ErrorOccuredEventHandler ErrorOccured;

    public WebRoutinenBase(IWebApiConfig settings)
    {
        // Settings werden kopiert, damit die abgeleiteten Klassen ggf. eigene Settings ergänzen/
        // ändern können (vor allem z.B. Base-URL)
        if (settings != null)
        {
            _originalSettings = settings;
            Settings = new WebApiSettings();
            Settings.CopyToThis(settings);
            if (settings is IJwtWebApiConfig jc)
            {
                IsJwt = true;
                JwtToken = jc.JwtToken;
            }

            if (settings.AuthToken?.Token != Guid.Empty && settings.AuthToken?.Expires > DateTime.UtcNow)
            {
                AuthToken = settings.AuthToken;
            }
        }
    }

    private async Task runPreRequestChecks(string url, bool skipAuth = false, [CallerMemberName] string sender = null)
    {
        if (_restRoutinen == null)
        {
            initRestRoutinen();
        }

        ThrowIfRateLimited(Settings.Url, sender);
        await CheckAuthorizedOrThrow(url, skipAuth, sender);

        // TODO: SYSLIB1045 in new Idas Api - upgrade to compile time REGEX for performance
        if (Regex.IsMatch(url, RelativeDateTimePattern))
        {
            var ex = new InvalidDateTimeKindException("The URL contains a datetime with a relative timezone offset (e.g. '+02:00'), which is not allowed. Please use ISO 8601 UTC format with a trailing 'Z', e.g. '2025-10-08T22:00:00.0000000Z'.");
            ex.Data.Add("URL", new Uri(new Uri(Settings.Url), url).ToString());
            ex.Data.Add("CallMethod", sender);
            throw ex;
        }
    }

    private async Task CheckAuthorizedOrThrow(string url, bool skipAuth, string sender)
    {
        if (!skipAuth && !await LoginAsync())
        {
            var ex = new ApiUnauthorizedException("You are not authorized.");
            ex.Data.Add("URL", new Uri(new Uri(Settings.Url), url).ToString());
            ex.Data.Add("CallMethod", sender);
            throw ex;
        }
    }

    private void ThrowIfRateLimited(string realativePath, string sender = null)
    {
        if (RateLimitRegistry.IsRateLimited(Settings.Url, out var resetTime))
        {
            var settingsUrl = new Uri(Settings.Url);
            var rateLimitEx = new RateLimitException(resetTime);
            var ex = new ApiException(rateLimitEx.Message, (HttpStatusCode)429, rateLimitEx);
            ex.Data.Add("URL", new Uri(settingsUrl, realativePath).ToString());
            ex.Data.Add("CallMethod", sender);
            ex.Data.Add("RateLimitReset", resetTime);
            throw ex;
        }
    }

    private void initRestRoutinen()
    {
        if (string.IsNullOrWhiteSpace(Settings.Url))
        {
            throw new ArgumentNullException(nameof(Settings.Url));
        }

        var config = new HttpClientConfig
        {
            BaseUrl = Settings.Url,
            UseCompression = Settings.UseCompression,
            UserAgent = Settings.UserAgent
        };

        if (IsJwt && !string.IsNullOrEmpty(JwtToken))
        {
            config.AdditionalHeaders.Add("Authorization", $"Bearer {JwtToken}");
        }
        else if (AuthToken != null)
        {
            config.AdditionalHeaders.Add("X-Gdl-AuthToken", AuthToken.Token.ToString());
        }

        if (Settings.InstallationId != Guid.Empty)
        {
            config.AdditionalHeaders.Add("X-Gdl-InstallationId", Settings.InstallationId.ToString());
        }

        config.NewApiOptInUrls = Settings.NewApiOptInUrls;

        _restRoutinen = new RESTRoutinen(config);
    }

    protected virtual void OnErrorOccured(ApiErrorArgs e)
    {
        ErrorOccured?.Invoke(this, e);
    }

    /// <summary>
    /// Meldet mit den aktuellen Credentials am Endpunkt /api/Login/Authenticate an. Wenn ein AuthToken vorhanden ist, wird
    /// zunächst versucht, dieses zu verwenden und ggf. zu updaten. Wenn das fehlschlägt, erfolgt eine Anmeldung mit Username/
    /// Passwort aus den Settings.
    /// </summary>
    /// <returns>Status des Logins</returns>
    public async Task<bool> LoginAsync()
    {
        if (IsJwt)
        {
            return await checkJwtTokenAsync();
        }

        try
        {
            UserAuthTokenDTO result = null;
            if (AuthToken == null || AuthToken.Expires < DateTime.UtcNow)
            {
                if (!string.IsNullOrEmpty(Settings.UserName) && !string.IsNullOrEmpty(Settings.Passwort))
                {
                    var lDto = new LoginDTO
                    {
                        Email = Settings.UserName,
                        Password = Settings.Passwort,
                        AppToken = Settings.AppToken
                    };
                    result = await PostAsync<UserAuthTokenDTO>("/api/Login/Authenticate", lDto, null, true);
                }
            }
            else
            {
                if (AuthToken.Expires < DateTime.UtcNow.AddHours(6))
                {
                    result = await SecurityRefreshTokenAsync(AuthToken.Token);
                }
                else
                {
                    Status = "OK (Cached)";
                    return true;
                }
            }

            if (result != null)
            {
                AuthToken = result;
                _originalSettings.AuthToken = result;
                initRestRoutinen();
                Status = "OK";
                return true;
            }

            AuthToken = null;
            Status = "Error";
            return false;
        }
        catch (ApiException apiEx)
        {
            L.Fehler(apiEx);
            Status = apiEx.Message;
            if (Status.ToLower().Contains("<title>"))
            {
                Status = internalStripHtml(Status);
            }

            var innerException = apiEx.InnerException;
            while (innerException != null)
            {
                Status += $" - {innerException.Message}";
                innerException = innerException.InnerException;
            }

            AuthToken = null;
            return false;
        }
        catch (Exception ex)
        {
            L.Fehler(ex);
            Status = ex.Message;
            AuthToken = null;
            return false;
        }
    }

    public async Task<UserAuthTokenDTO> RefreshTokenAsync(Guid authTokenGuid)
    {
        return await SecurityRefreshTokenAsync(authTokenGuid);
    }

    public async Task<UserAuthTokenDTO> SecurityRefreshTokenAsync(Guid authTokenGuid)
    {
        try
        {
            return await PutAsync<UserAuthTokenDTO>("/api/Login/Update", new UserAuthTokenDTO { Token = authTokenGuid }, null, true);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<T> PostAsync<T>(string uri, object data, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.PostAsync<T>(uri, data, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return default;
    }

    public async Task PostAsync(string uri, object data, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            await _restRoutinen.PostAsync(uri, data, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }
    }

    public async Task<byte[]> PostDataAsync(string uri, byte[] data, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.PostDataAsync(uri, data, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return null;
    }

    public async Task<byte[]> PostDataAsync(string uri, HttpContent data, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.PostDataAsync(uri, data, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return null;
    }

    public async Task<byte[]> GetDataAsync(string uri, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.GetDataAsync(uri, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return null;
    }

    public async Task<string> GetAsync(string uri, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.GetAsync(uri, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return null;
    }

    public async Task<T> GetAsync<T>(string uri, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.GetAsync<T>(uri, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return default;
    }

    public async Task PutAsync(string uri, object data, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            await _restRoutinen.PutAsync(uri, data, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }
    }

    public async Task<T> PutAsync<T>(string uri, object data, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.PutAsync<T>(uri, data, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return default;
    }

    public async Task<byte[]> PutDataAsync(string uri, byte[] data, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.PutDataAsync(uri, data);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
            return null;
        }
    }

    public async Task<byte[]> PutDataAsync(string uri, HttpContent data, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.PutDataAsync(uri, data);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return null;
    }

    public async Task DeleteAsync(string uri, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            await _restRoutinen.DeleteAsync(uri);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }
    }

    public async Task DeleteAsync(string uri, object data, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            await _restRoutinen.DeleteAsync(uri, data, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }
    }

    public async Task<T> DeleteAsync<T>(string uri, object data, bool skipAuth = false, string version = null)
    {
        try
        {
            await runPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.DeleteAsync<T>(uri, data, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception);
        }
        catch (Exception e)
        {
            TryHandleException(e);
        }

        return default;
    }

    private static string internalStripHtml(string htmlString)
    {
        var result = htmlString;
        if (result.ToLower().Contains("<title>") && result.ToLower().Contains("</title>"))
        {
            var start = result.IndexOf("<title>") + 7;
            var end = result.IndexOf("</title>");
            if (end > start)
            {
                result = $"Interner Serverfehler (\"{result.Substring(start, end - start)}\"). Bitte versuchen Sie es zu einem späteren Zeitpunkt erneut.";
            }
        }

        return result;
    }

    private async Task<bool> checkJwtTokenAsync()
    {
        if (internalCheckJwtToken(out var refreshToken, out var checkResult))
        {
            return checkResult;
        }

        try
        {
            var loginConfig = Settings;
            //temporarily create new Settings if the base url is not the IDASUrl since the refresh can only happen on the IDAS backend
            if (Settings.Url != Settings.IDASUrl)
            {
                loginConfig = new JwtWebApiSettings();
                loginConfig.CopyToThis(Settings);
                loginConfig.Url = Settings.IDASUrl;
            }

            // refresh JWT using refresh token
            var newJwt = await new WebRoutinenBase(loginConfig).PutAsync<string>("/api/LoginJwt/Refresh", new { Token = refreshToken }, null, true);
            if (_originalSettings is IJwtWebApiConfig jc)
            {
                jc.JwtToken = newJwt;
            }
            JwtToken = newJwt;
            return true;
        }
        catch (ApiException apiEx)
        {
            L.Fehler(apiEx);
            Status = apiEx.Message;
            if (Status.ToLower().Contains("<title>"))
            {
                Status = internalStripHtml(Status);
            }

            var innerException = apiEx.InnerException;
            while (innerException != null)
            {
                Status += $" - {innerException.Message}";
                innerException = innerException.InnerException;
            }

            JwtToken = null;
            return false;
        }
        catch (Exception ex)
        {
            L.Fehler(ex);
            Status = ex.Message;
            JwtToken = null;
            return false;
        }
    }

    private bool internalCheckJwtToken(out string refreshToken, out bool checkResult)
    {
        refreshToken = null;
        var tokenHandler = new JwtSecurityTokenHandler();
        if (!tokenHandler.CanReadToken(JwtToken))
        {
            // unreadable
            checkResult = false;
            return true;
        }

        var jwtToken = tokenHandler.ReadJwtToken(JwtToken);
        if (jwtToken.ValidTo >= DateTime.UtcNow)
        {
            // token is not expired
            checkResult = true;
            return true;
        }

        var tokenType = "Normal";
        var tokenTypeClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "type");
        if (tokenTypeClaim != null)
        {
            tokenType = tokenTypeClaim.Value;
        }

        var refreshTokenClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "refreshToken");
        refreshToken = refreshTokenClaim?.Value;
        Guid.TryParse(refreshToken, out var refreshTokenGuid);

        // Service tokens can have refreshTokenGuid empty
        if (tokenType != "Service" &&
            refreshTokenClaim == null ||
            refreshTokenGuid == Guid.Empty)
        {
            // JWT is expired and has no refreshToken
            checkResult = false;
            return true;
        }

        // token is good - return "false" for further processing
        checkResult = true;
        return false;
    }

    /// <summary>
    /// Checks if a <see cref="CustomExceptionHandler"/> can handle the exception. If not, will throw the Exception.
    /// </summary>
    /// <param name="exception">Exception to check</param>
    /// <exception cref="Exception">Throws <paramref name="exception"/>, if no <see cref="CustomExceptionHandler"/> handles the exception</exception>
    private void TryHandleException(Exception exception)
    {
        exception.Data.Add("BenutzerGuid", AuthToken?.Benutzer?.BenutzerGuid);
        exception.Data.Add("MandantGuid", AuthToken?.MandantGuid);

        L.Fehler(exception);

        if (!IgnoreOnErrorOccured)
        {

            if (CustomExceptionHandler != null && CustomExceptionHandler.GetInvocationList().Cast<ExceptionHandler>().Any(handler => handler(exception)))
            {
                return;
            }

            throw exception;
        }
    }

    private Exception HandleWebException(
        HttpRequestException ex,
        string url,
        object data = null,
        [CallerMemberName] string sender = null)
    {
        var exception = TranslateException(ex, data);

        TryUpdateRateLimitRegistry(exception);

        if (exception.StatusCode == HttpStatusCode.Unauthorized)
        {
            return new ApiUnauthorizedException(Status = ex.Message);
        }

        return InternalHandleWebException(exception, url, sender);
    }

    private void TryUpdateRateLimitRegistry(ApiException exception)
    {
        if (exception?.StatusCode == (HttpStatusCode)429 &&
            exception.ProblemDetails?.TryGetResetDateTimeUtc(out var resetDateTimeUtc) == true)
        {
            RateLimitRegistry.SetRateLimited(Settings.Url, resetDateTimeUtc);
        }
    }

    private ApiException InternalHandleWebException(ApiException exception, string url, [CallerMemberName] string sender = null)
    {
        if (!IgnoreOnErrorOccured)
        {
            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
        }

        var foundUrlInData = false;

        // Check if we already have data from RESTRoutinen.AddInfoToException()
        if (!exception.Data.Contains("URL"))
        {
            var innerException = exception.InnerException;
            while (innerException != null)
            {
                if (innerException.Data.Contains("URL"))
                {
                    foundUrlInData = true;
                }

                innerException = innerException.InnerException;
            }
        }
        else
        {
            foundUrlInData = true;
        }

        if (!foundUrlInData)
        {
            exception.Data.Add("URL", new Uri(new Uri(Settings.Url), url).ToString());
            exception.Data.Add("CallMethod", sender);
            exception.Data.Add("StatusCode", exception.StatusCode);
            exception.Data.Add("Payload", exception.Payload);
        }

        // Add data from ProblemDetails if available
        if (exception.ProblemDetails != null)
        {
            exception.Data.Add("ProblemDetails.Title", exception.ProblemDetails.Title);
            exception.Data.Add("ProblemDetails.Type", exception.ProblemDetails.Type);
            exception.Data.Add("ProblemDetails.Detail", exception.ProblemDetails.Detail);
            exception.Data.Add("ProblemDetails.Instance", exception.ProblemDetails.Instance);
        }

        return exception;
    }

    protected static ApiException TranslateException(HttpRequestException ex, object payload = null)
    {
        if (!ex.Data.Contains("StatusCode"))
        {
            return new ApiException(ex.Message, ex, payload);
        }

        var response = ex.Data.Contains("Response") ? (string)ex.Data["Response"] : string.Empty;
        var code = (HttpStatusCode)ex.Data["StatusCode"];

        if (string.IsNullOrWhiteSpace(response))
        {
            return new ApiException(ex.Message, code, ex, payload);
        }

        if (TryDeserializeProblemDetails(response, out var problemDetails))
        {
            if (problemDetails.Status == 429 && problemDetails.TryGetResetDateTimeUtc(out var resetDateTimeUtc))
            {
                var rateLimitEx = new RateLimitException(resetDateTimeUtc, ex);
                return new ApiException(problemDetails.Detail ?? problemDetails.Title, code, rateLimitEx, problemDetails, payload);
            }

            return new ApiException(problemDetails.Detail ?? problemDetails.Title, code, problemDetails, payload);
        }

        if (TryDeserializeException(response, out var originalException))
        {
            return new ApiException(originalException.Message, code, originalException, payload);
        }

        if (TryDeserializeDynamic(response, out var status, out var dynamicException))
        {
            return new ApiException(status, code, ex, payload) { ExceptionString = dynamicException };
        }

        return new ApiException(response, code, ex, payload);
    }

    private static bool TryDeserializeException(string json, out Exception exception)
    {
        exception = null!;

        if (!json.Contains("$type"))
        {
            return false;
        }

        try
        {
            exception = JsonConvert.DeserializeObject<Exception>(json,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return exception != null;
        }
        catch
        {
            return false;
        }
    }

    private static bool TryDeserializeProblemDetails(string json, out ProblemDetails problemDetails)
    {
        problemDetails = null!;

        try
        {
            problemDetails = JsonConvert.DeserializeObject<ProblemDetails>(json);

            var isValid = problemDetails != null &&
                          problemDetails.Status.HasValue &&
                          (!string.IsNullOrEmpty(problemDetails.Title) ||
                          !string.IsNullOrEmpty(problemDetails.Type) ||
                          !string.IsNullOrEmpty(problemDetails.Detail));

            return isValid;
        }
        catch
        {
            return false;
        }
    }

    private static bool TryDeserializeDynamic(string json, out string status, out string dynamicException)
    {
        status = null!;
        dynamicException = null!;

        dynamic dynamicObject;

        try
        {
            dynamicObject = JsonConvert.DeserializeObject<dynamic>(json);
            status = dynamicObject.status;
            dynamicException = dynamicObject.exception?.ToString();
            return true;
        }
        catch
        {
            return false;
        }
    }
}

internal sealed class InvalidDateTimeKindException : Exception
{
    public InvalidDateTimeKindException() : base() { }
    public InvalidDateTimeKindException(string message) : base(message) { }
    public InvalidDateTimeKindException(string message, Exception innerException) : base(message, innerException) { }
}

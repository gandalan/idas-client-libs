// *****************************************************************************
// Gandalan GmbH & Co. KG - (c) 2023
// *****************************************************************************
// Middleware//Gandalan.IDAS.WebApi.Client//WebRoutinenBase.cs
// Created: 27.01.2016
// Edit: phil - 31.05.2023 11:57
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
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
    private readonly Lazy<RESTRoutinen> _restRoutinen;
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
    /// Used to register custom handlers to catch Exceptions thrown by all <see cref="WebRoutinenBase"/>
    /// <seealso cref="DisableCustomExceptionHandler"/>
    /// </summary>
    public static event ExceptionHandler CustomExceptionHandler;
    /// <summary>
    /// Disable/ignore registered <see cref="CustomExceptionHandler"/> for this instance
    /// </summary>
    public bool DisableCustomExceptionHandler { get; set; }

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

        _restRoutinen = new Lazy<RESTRoutinen>(InitRestRoutinen, LazyThreadSafetyMode.ExecutionAndPublication);
    }

    private async Task RunPreRequestChecks(string url, bool skipAuth = false, [CallerMemberName] string sender = null)
    {
        _ = _restRoutinen.Value;

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

    private RESTRoutinen InitRestRoutinen()
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

        // InstallationId is stable and can remain in DefaultRequestHeaders.
        // Auth headers (token / JWT) are intentionally excluded here: they are
        // injected per-request via UpdatePerRequestHeaders so that token refreshes
        // never cause a new HttpClient to be created in the static factory cache.
        if (Settings.InstallationId != Guid.Empty)
        {
            config.AdditionalHeaders.Add("X-Gdl-InstallationId", Settings.InstallationId.ToString());
        }

        config.NewApiOptInUrls = Settings.NewApiOptInUrls;

        var restRoutinen = new RESTRoutinen(config);
        restRoutinen.UpdatePerRequestHeaders(BuildAuthHeaders());
        return restRoutinen;
    }

    private Dictionary<string, string> BuildAuthHeaders()
    {
        var headers = new Dictionary<string, string>();
        if (IsJwt && !string.IsNullOrEmpty(JwtToken))
        {
            headers["Authorization"] = $"Bearer {JwtToken}";
        }
        else if (AuthToken != null)
        {
            headers["X-Gdl-AuthToken"] = AuthToken.Token.ToString();
        }
        return headers.Count > 0 ? headers : null;
    }

    private void UpdateAuthInRestRoutinen()
    {
        if (_restRoutinen.IsValueCreated)
            _restRoutinen.Value.UpdatePerRequestHeaders(BuildAuthHeaders());
    }

    /// <summary>
    /// Annotates <paramref name="exception"/>.Data with every diagnostic field we know about at this point
    /// (URL, status, payload, settings, auth state, response body, ProblemDetails, etc.) so the failure
    /// is fully reconstructable from logs / forwarded mails. Idempotent: keys already present are kept.
    /// </summary>
    private void EnrichExceptionData(Exception exception, string relativeUrl, object payload, string sender)
    {
        if (exception == null)
        {
            return;
        }

        void TryAdd(string key, object value)
        {
            if (value == null)
            {
                return;
            }

            try
            {
                if (exception.Data.Contains(key))
                {
                    return;
                }

                exception.Data.Add(key, value);
            }
            catch
            {
                // value not serializable into IDictionary — ignore, never let diagnostics break the failure path
            }
        }

        TryAdd("TimestampUtc", DateTime.UtcNow.ToString("O"));
        TryAdd("CallMethod", sender);

        if (!string.IsNullOrEmpty(relativeUrl))
        {
            if (!string.IsNullOrEmpty(Settings?.Url))
            {
                try
                {
                    TryAdd("URL", new Uri(new Uri(Settings.Url), relativeUrl).ToString());
                }
                catch
                {
                    TryAdd("URL", relativeUrl);
                }
            }
            else
            {
                TryAdd("URL", relativeUrl);
            }
        }

        TryAdd("BaseUrl", Settings?.Url);
        TryAdd("UserAgent", Settings?.UserAgent);
        TryAdd("UserName", Settings?.UserName);

        if (Settings != null && Settings.InstallationId != Guid.Empty)
        {
            TryAdd("InstallationId", Settings.InstallationId.ToString());
        }

        TryAdd("AuthMode", IsJwt ? "JWT" : (AuthToken != null ? "AuthToken" : "None"));

        if (IsJwt)
        {
            TryAdd("HasJwtToken", (!string.IsNullOrEmpty(JwtToken)).ToString());
        }

        if (AuthToken != null)
        {
            TryAdd("AuthTokenExpiresUtc", AuthToken.Expires.ToString("O"));
            TryAdd("BenutzerGuid", AuthToken.Benutzer?.BenutzerGuid);
            TryAdd("MandantGuid", AuthToken.MandantGuid);
        }

        if (payload != null && !exception.Data.Contains("Payload"))
        {
            try
            {
                TryAdd("Payload", JsonConvert.SerializeObject(payload));
            }
            catch
            {
                TryAdd("Payload", payload.ToString());
            }
        }

        if (exception is ApiException apiException)
        {
            TryAdd("StatusCode", apiException.StatusCode);
            if (!string.IsNullOrEmpty(apiException.Payload))
            {
                TryAdd("Payload", apiException.Payload);
            }

            if (!string.IsNullOrEmpty(apiException.ExceptionString))
            {
                TryAdd("ExceptionString", apiException.ExceptionString);
            }

            if (apiException.ProblemDetails != null)
            {
                TryAdd("ProblemDetails.Title", apiException.ProblemDetails.Title);
                TryAdd("ProblemDetails.Type", apiException.ProblemDetails.Type);
                TryAdd("ProblemDetails.Detail", apiException.ProblemDetails.Detail);
                TryAdd("ProblemDetails.Instance", apiException.ProblemDetails.Instance);
                TryAdd("ProblemDetails.Status", apiException.ProblemDetails.Status);
            }
        }

        // Promote response body from inner HttpRequestException into top-level Data so it shows up in dumps
        var currentException = exception;

        var depth = 0;

        while (currentException != null && depth < 10)
        {
            if (currentException.Data.Contains("Response"))
            {
                var resp = currentException.Data["Response"]?.ToString();
                if (!string.IsNullOrEmpty(resp))
                {
                    if (resp.Length > 4000)
                    {
#if NET48
                        resp = resp.Substring(0, 4000) + " ...(truncated)";
#else
                        resp = string.Concat(resp.AsSpan(0, 4000), " ...(truncated)");
#endif
                    }

                    TryAdd("Response", resp);
                }

                break;
            }

            currentException = currentException.InnerException;
            depth++;
        }
    }

    /// <summary>
    /// Propagates the current <see cref="AuthToken"/> / <see cref="JwtToken"/> to all subsequent
    /// outgoing requests as per-request headers. Call this after manually setting
    /// <see cref="AuthToken"/> outside of <see cref="LoginAsync"/>.
    /// </summary>
    public void UpdateAuthHeaders()
    {
        UpdateAuthInRestRoutinen();
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
            return await CheckJwtTokenAsync();
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
                    result = await RefreshTokenAsync(AuthToken.Token);
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
                UpdateAuthInRestRoutinen();
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
                Status = InternalStripHtml(Status);
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

    /// <summary>
    /// Erneuert das Auth-Token am Endpunkt /api/Login/Update und aktualisiert
    /// die Instanz sowie alle ausgehenden Requests sofort mit dem neuen Token.
    /// Konsistent mit dem Verhalten von <see cref="LoginAsync"/>.
    /// </summary>
    public async Task<UserAuthTokenDTO> RefreshTokenAsync(Guid authTokenGuid)
    {
        try
        {
            var result = await PutAsync<UserAuthTokenDTO>("/api/Login/Update", new UserAuthTokenDTO { Token = authTokenGuid }, null, true);
            if (result != null)
            {
                AuthToken = result;
                _originalSettings.AuthToken = result;
                UpdateAuthInRestRoutinen();
            }
            return result;
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
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.PostAsync<T>(uri, data, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri, data);
        }

        return default;
    }

    public async Task PostAsync(string uri, object data, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            await _restRoutinen.Value.PostAsync(uri, data, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri, data);
        }
    }

    public async Task<byte[]> PostDataAsync(string uri, byte[] data, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.PostDataAsync(uri, data, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri, data);
        }

        return null;
    }

    public async Task<byte[]> PostDataAsync(string uri, HttpContent data, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.PostDataAsync(uri, data, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri, data);
        }

        return null;
    }

    public async Task<byte[]> GetDataAsync(string uri, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.GetDataAsync(uri, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception, uri);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri);
        }

        return null;
    }

    public async Task<string> GetAsync(string uri, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.GetAsync(uri, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception, uri);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri);
        }

        return null;
    }

    public async Task<T> GetAsync<T>(string uri, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.GetAsync<T>(uri, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception, uri);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri);
        }

        return default;
    }

    public async Task PutAsync(string uri, object data, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            await _restRoutinen.Value.PutAsync(uri, data, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri, data);
        }
    }

    public async Task<T> PutAsync<T>(string uri, object data, JsonSerializerSettings settings = null, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.PutAsync<T>(uri, data, settings, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri, data);
        }

        return default;
    }

    public async Task<byte[]> PutDataAsync(string uri, byte[] data, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.PutDataAsync(uri, data);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
            return null;
        }
    }

    public async Task<byte[]> PutDataAsync(string uri, HttpContent data, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.PutDataAsync(uri, data);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri, data);
        }

        return null;
    }

    public async Task DeleteAsync(string uri, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            await _restRoutinen.Value.DeleteAsync(uri);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception, uri);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri);
        }
    }

    public async Task DeleteAsync(string uri, object data, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            await _restRoutinen.Value.DeleteAsync(uri, data, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri, data);
            TryHandleException(exception, uri, data);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri, data);
        }
    }

    public async Task<T> DeleteAsync<T>(string uri, object data, bool skipAuth = false, string version = null)
    {
        try
        {
            await RunPreRequestChecks(uri, skipAuth);
            return await _restRoutinen.Value.DeleteAsync<T>(uri, data, version: version);
        }
        catch (HttpRequestException ex)
        {
            var exception = HandleWebException(ex, uri);
            TryHandleException(exception, uri);
        }
        catch (Exception e)
        {
            TryHandleException(e, uri);
        }

        return default;
    }

    private static string InternalStripHtml(string htmlString)
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

    private async Task<bool> CheckJwtTokenAsync()
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
            UpdateAuthInRestRoutinen();
            return true;
        }
        catch (ApiException apiEx)
        {
            L.Fehler(apiEx);
            Status = apiEx.Message;
            if (Status.ToLower().Contains("<title>"))
            {
                Status = InternalStripHtml(Status);
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
    /// Also enriches <paramref name="exception"/>.Data with full request/auth/state diagnostics before logging.
    /// </summary>
    /// <param name="exception">Exception to check</param>
    /// <param name="url">Relative URL of the failing request, used for the URL diagnostic field</param>
    /// <param name="payload">Request payload to serialize into Data if not already captured</param>
    /// <param name="sender">Calling method (auto-filled via <see cref="CallerMemberNameAttribute"/>)</param>
    /// <exception cref="Exception">Throws <paramref name="exception"/>, if no <see cref="CustomExceptionHandler"/> handles the exception</exception>
    private void TryHandleException(Exception exception, string url = null, object payload = null, [CallerMemberName] string sender = null)
    {
        EnrichExceptionData(exception, url, payload, sender);

        L.Fehler(exception);

        if (IgnoreOnErrorOccured)
        {
            return;
        }

        if (!DisableCustomExceptionHandler && CustomExceptionHandler != null && CustomExceptionHandler.GetInvocationList().Cast<ExceptionHandler>().Any(handler => handler(exception)))
        {
            return;
        }

        throw exception;
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
            Status = ex.Message;
            var unauthorized = new ApiUnauthorizedException(exception.Message);
            EnrichExceptionData(unauthorized, url, data, sender);
            return unauthorized;
        }

        return InternalHandleWebException(exception, url, data, sender);
    }

    private void TryUpdateRateLimitRegistry(ApiException exception)
    {
        if (exception?.StatusCode == (HttpStatusCode)429 &&
            exception.ProblemDetails?.TryGetResetDateTimeUtc(out var resetDateTimeUtc) == true)
        {
            RateLimitRegistry.SetRateLimited(Settings.Url, resetDateTimeUtc);
        }
    }

    private ApiException InternalHandleWebException(ApiException exception, string url, object payload = null, [CallerMemberName] string sender = null)
    {
        if (!IgnoreOnErrorOccured)
        {
            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
        }

        EnrichExceptionData(exception, url, payload, sender);

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
            // Title/Detail can both be null when only Type is set — fall back so the base Exception.Message
            // is never the default "Exception of type 'X' was thrown" placeholder.
            var problemMessage = problemDetails.Detail
                ?? problemDetails.Title
                ?? problemDetails.Type
                ?? $"HTTP {(int)code} {code}";

            if (problemDetails.Status == 429)
            {
                var resetDateTimeUtc = problemDetails.TryGetResetDateTimeUtc(out var resetTime)
                    ? resetTime
                    : DateTime.UtcNow.AddMinutes(1);
                var rateLimitEx = new RateLimitException(resetDateTimeUtc, ex);
                return new ApiException(problemMessage, code, rateLimitEx, problemDetails, payload);
            }

            return new ApiException(problemMessage, code, problemDetails, payload);
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

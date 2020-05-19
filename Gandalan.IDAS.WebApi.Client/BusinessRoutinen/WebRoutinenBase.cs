// *****************************************************************************
// Gandalan GmbH & Co. KG - (c) 2017
// *****************************************************************************
// Middleware//Gandalan.IDAS.WebApi.Client//WebRoutinenBase.cs
// Created: 27.01.2016
// Edit: phil - 21.02.2017
// *****************************************************************************

using System;
using System.Net;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.Web;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client
{
    public class WebRoutinenBase : RESTClientBase
    {
        #region  Felder

        public WebApiSettings Settings;

        #endregion

        #region  Eigenschaften

        public UserAuthTokenDTO AuthToken { get; set; }
        public string Status { get; private set; }
        public bool IgnoreOnErrorOccured { get; set; }

        #endregion

        public static event ErrorOccuredEventHandler ErrorOccured;

        public delegate void ErrorOccuredEventHandler(object sender, ApiErrorArgs e);

        public WebRoutinenBase(WebApiSettings settings)
        {
            // Settings werden kopiert, damit die abgeleiteten Klassen ggf. eigene Settings ergänzen/
            // ändern können (vor allem z.B. Base-URL)
            if (settings != null)
            {
                Settings = new WebApiSettings()
                {
                    AppToken = settings.AppToken,
                    AuthToken = settings.AuthToken,
                    FriendlyName = settings.FriendlyName,
                    Mandant = settings.Mandant,
                    Passwort = settings.Passwort,
                    Url = settings.Url,
                    UserName = settings.UserName,
                    InstallationId = settings.InstallationId,
                    UserAgent = settings.UserAgent
                };
            }

            if (settings?.AuthToken?.Token != Guid.Empty && settings?.AuthToken?.Expires > DateTime.UtcNow)
            {
                AuthToken = settings.AuthToken;
            }
        }

        protected virtual void OnErrorOccured(ApiErrorArgs e)
        {
            if (e.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ApiUnauthorizedException(Status = e.Message);
            }

            ErrorOccured?.Invoke(this, e);
        }

        /// <summary>
        /// Meldet mit den aktuellen Credentials am Endpunkt /api/Login/Authenticate an. Wenn ein AuthToken vorhanden ist, wird 
        /// zunächst versucht, dieses zu verwenden und ggf. zu updaten. Wenn das fehlschlägt, erfolgt eine Anmeldung mit Username/
        /// Passwort aus den Settings.
        /// </summary>
        /// <returns>Status des Logins</returns>
        public bool Login()
        {
            try
            {
                UserAuthTokenDTO result = null;
                if (AuthToken == null || AuthToken.Expires < DateTime.UtcNow)
                {
                    var ldto = new LoginDTO()
                    {
                        Email = Settings.UserName,
                        Password = Settings.Passwort,
                        AppToken = Settings.AppToken
                    };
                    result = Post<UserAuthTokenDTO>("/api/Login/Authenticate", ldto);
                }
                else
                {
                    if (AuthToken.Expires < DateTime.UtcNow.AddHours(6))
                    {
                        result = Put<UserAuthTokenDTO>("/api/Login/Update", AuthToken);
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
                    Status = "OK";
                    return true;
                }
                else
                {
                    AuthToken = null;
                    Status = "Error";
                    return false;
                }
            }
            catch (ApiException apiex)
            {
                Status = apiex.Message;
                if (Status.ToLower().Contains("<title>"))
                {
                    Status = internalStripHtml(Status);
                }

                if (apiex.InnerException != null)
                    Status += " - " + apiex.InnerException.Message;
                AuthToken = null;
                return false;
            }
            catch (Exception ex)
            {
                Status = ex.Message;
                AuthToken = null;
                return false;
            }
        }

        public UserAuthTokenDTO RefreshToken(Guid authTokenGuid)
        {
            try
            {
                return Put<UserAuthTokenDTO>("/api/Login/Update", new UserAuthTokenDTO() {Token = authTokenGuid});
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T Post<T>(string uri, object data, JsonSerializerSettings settings = null)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Post<T>(uri, data, settings);
                }
                catch (WebException ex)
                {
                    ApiException exception = TranslateException(ex, data);
                    if (!IgnoreOnErrorOccured)
                    {
                        OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                    }

                    throw exception;
                }
            }
        }

        public string Post(string uri, object data, JsonSerializerSettings settings = null)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Post(uri, data, settings);
                }
                catch (WebException ex)
                {
                    ApiException exception = TranslateException(ex, data);
                    if (!IgnoreOnErrorOccured)
                    {
                        OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                    }

                    throw exception;
                }
            }
        }

        public byte[] PostData(string uri, byte[] data)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.PostData(uri, data);
                }
                catch (WebException ex)
                {
                    ApiException exception = TranslateException(ex, data);
                    if (!IgnoreOnErrorOccured)
                    {
                        OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                    }

                    throw exception;
                }
            }
        }

        public string Get(string uri)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Get(uri);
                }
                catch (WebException ex)
                {
                        ApiException exception = TranslateException(ex);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public byte[] GetData(string uri)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.GetData(uri);
                }
                catch (WebException ex)
                {
                        ApiException exception = TranslateException(ex);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public T Get<T>(string uri, JsonSerializerSettings settings = null)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Get<T>(uri, settings);
                }
                catch (WebException ex)
                {
                        ApiException exception = TranslateException(ex);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public T Put<T>(string uri, object data, JsonSerializerSettings settings = null)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Put<T>(uri, data, settings);
                }
                catch (WebException ex)
                {
                        ApiException exception = TranslateException(ex, data);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public string Put(string uri, object data, JsonSerializerSettings settings = null)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Put(uri, data, settings);
                }
                catch (WebException ex)
                {
                        ApiException exception = TranslateException(ex, data);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public byte[] PutData(string uri, byte[] data)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.PutData(uri, data);
                }
                catch (WebException ex)
                {
                        ApiException exception = TranslateException(ex, data);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public T Delete<T>(string uri, object data, JsonSerializerSettings settings = null) 
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Delete<T>(uri, data, settings);
                }
                catch (WebException ex)
                {
                        ApiException exception = TranslateException(ex, data);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public T Delete<T>(string uri, JsonSerializerSettings settings = null) 
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Delete<T>(uri, settings);
                }
                catch (WebException ex)
                {
                        ApiException exception = TranslateException(ex);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public string Delete(string uri)
        {
            using (var cl = new RESTRoutinen(Settings.Url))
            {
                try
                {
                    if (AuthToken != null)
                    {
                        cl.AdditionalHeaders.Add("X-Gdl-AuthToken: " + AuthToken.Token);
                    }
                    if (Settings.InstallationId != Guid.Empty)
                        cl.AdditionalHeaders.Add("X-Gdl-InstallationId: " + Settings.InstallationId);
                    if (!String.IsNullOrEmpty(Settings.UserAgent))
                        cl.UserAgent = Settings.UserAgent;

                    return cl.Delete(uri);
                }
                catch (WebException ex)
                {
                    ApiException exception = TranslateException(ex);
                        if (!IgnoreOnErrorOccured)
                        {
                            OnErrorOccured(new ApiErrorArgs(exception.Message, exception.StatusCode));
                        }

                        throw exception;
                }
            }
        }

        public async Task<bool> LoginAsync()
        {
            return await Task.Run(() => Login());
        }

        private string internalStripHtml(string htmlString)
        {
            var result = htmlString;
            if (result.ToLower().Contains("<title>") && result.ToLower().Contains("</title>"))
            {
                var start = result.IndexOf("<title>") + 7;
                var end = result.IndexOf("</title>");
                if (end > start)
                    result = $"Interner Serverfehler (\"{result.Substring(start, end - start)}\"). Bitte versuchen Sie es zu einem späteren Zeitpunkt erneut.";
            }
            return result;
        }
    }
}
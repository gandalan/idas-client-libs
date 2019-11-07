using Newtonsoft.Json;
using System.Net;
using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.Web
{
    /// <summary>
    /// Klasse für den HTTP-Datentransfer per REST an unsere WebAPIs. Ermöglicht das Senden 
    /// und Empfangen von Objekten. Die Übermittlung erfolgt mit JSON serialisierten Objekten.
    /// </summary>
    public class RESTRoutinen : IDisposable
    {
        #region Constructors
        public RESTRoutinen()
        {
            AdditionalHeaders = new List<string>();
        }

        public RESTRoutinen(string baseUrl) : this()
        {
            BaseUrl = baseUrl;
        }

        public RESTRoutinen(string baseUrl, IWebProxy proxy) : this()
        {
            BaseUrl = baseUrl;
            Proxy = proxy;
        }
        #endregion Constructors

        #region public Properties
        /// <summary>
        /// Stammadresse der Web-API. Die Resource-Parameter der einzelnen Übertragungsmethoden 
        /// werden angehängt. Beispiel: http://192.168.217.10/neurosAPI/api/
        /// </summary>
        public string BaseUrl { get; set; }
        /// <summary>
        /// Proxy-Informationen (optional)
        /// </summary>
        public IWebProxy Proxy { get; set; }
        /// <summary>
        /// Liste der zusätzlich zu übermittelnden Header. Werden bei jeder Anfrage mitgeschickt, 
        /// z.B. für Authentifizierungs-Header
        /// </summary>
        public List<string> AdditionalHeaders { get; private set; }
        public ICredentials Credentials { get; set; }
        /// <summary>
        /// User-Agent Header. Wird bei jeder Anfrage mitgeschickt.
        /// </summary>
        public string UserAgent { get; set; }
        #endregion

        #region public Methods
        /// <summary>
        /// Holt ein Objekt per HTTP GET 
        /// </summary>
        /// <typeparam name="T">Typsierungsparameter</typeparam>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <param name="settings"></param>
        /// <returns>Objektinstanz</returns>
        public T Get<T>(string url, JsonSerializerSettings settings = null)
        {
            WebClient client = createWebClient();
            try
            {
                return JsonConvert.DeserializeObject<T>(Get(url), settings);
            }
            catch
            #region Code
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
            #endregion
        }

        public string Get(string url)
        {
            WebClient client = createWebClient();
            try
            {
                return client.DownloadString(url);
            }
            catch
            #region Code
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
            #endregion
        }

        public byte[] GetData(string url)
        {
            WebClient client = createWebClient();
            try
            {
                return client.DownloadData(url);
            }
            catch
            #region Code
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
            #endregion
        }
        /// <summary>
        /// Sendet ein Objekt per HTTP POST an die angegebene URL, i.d.R. um es zu speichern 
        /// </summary>
        /// <typeparam name="T">Typisierungsparameter</typeparam>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <param name="data">zu sendendes Objekt</param>
        /// <param name="settings"></param>
        /// <returns>deserialisierte Antwort (i.d.R. sollte das das gespeicherte Objekt in seiner Endfassung sein)</returns>
        public T Post<T>(string url, object data, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(Post(url, data, settings), settings);
        }

        public string Post(string url, object data, JsonSerializerSettings settings = null)
        {
            System.Net.WebClient client = createWebClient();
            try
            {
                string json = JsonConvert.SerializeObject(data, settings);
                return client.UploadString(url, "POST", json);
            }
            catch
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        public byte[] PostData(string url, byte[] data)
        {
            WebClient client = createWebClient();
            try
            {
                return client.UploadData(url, "POST", data);
            }
            catch
            #region Code
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
            #endregion
        }

        /// <summary>
        /// Sendet ein Objekt per HTTP PUT an die angegebene URL, i.d.R. um es anzulegen
        /// </summary>
        /// <typeparam name="T">Typisierungsparameter</typeparam>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <param name="data">zu sendendes Objekt</param>
        /// <param name="settings"></param>
        /// <returns>deserialisierte Antwort (i.d.R. sollte das das gespeicherte Objekt in seiner Endfassung sein)</returns>
        public T Put<T>(string url, object data, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(Put(url, data, settings), settings);
        }

        public string Put(string url, object data, JsonSerializerSettings settings = null)
        {
            WebClient client = createWebClient();
            try
            {
                string json = JsonConvert.SerializeObject(data, settings);
                return client.UploadString(url, "PUT", json);
            }
            catch
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        public byte[] PutData(string url, byte[] data)
        {
            WebClient client = createWebClient();
            try
            {
                return client.UploadData(url, "PUT", data);
            }
            catch
            #region Code
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
            #endregion
        }

        /// <summary>
        /// Löscht ein Objekt per HTTP DELETE an die angegebene URL
        /// </summary>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <returns>Antwort des Servers als String</returns>
        public string Delete(string url)
        {
            WebClient client = createWebClient();
            try
            {
                return client.UploadString(url, "DELETE", "");
            }
            catch
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        /// <summary>
        /// Löscht ein Objekt per HTTP DELETE an die angegebene URL
        /// </summary>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <param name="data"></param>
        /// <param name="settings"></param>
        /// <returns>Antwort des Servers als String</returns>
        public T Delete<T>(string url, object data, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(Delete(url, data, settings), settings);
        }

        /// <summary>
        /// Löscht ein Objekt per HTTP DELETE an die angegebene URL
        /// </summary>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <param name="settings"></param>
        /// <returns>Antwort des Servers als String</returns>
        public T Delete<T>(string url, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(Delete(url), settings);
        }

        public string Delete(string url, object data, JsonSerializerSettings settings = null)
        {
            WebClient client = createWebClient();
            try
            {
                string json = JsonConvert.SerializeObject(data, settings);
                return client.UploadString(url, "DELETE", json);
            }
            catch
            {
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }
        #endregion

        #region private Methods
        /// <summary>
        /// Erstellt und konfiguriert eine neue WebClient-Instanz 
        /// </summary>
        /// <returns></returns>
        private WebClient createWebClient()
        {
            GDLWebClient client = new GDLWebClient();
            if (this.Credentials != null)
                client.Credentials = this.Credentials;
            client.BaseAddress = BaseUrl;
            client.Timeout = 120000;
            if (!string.IsNullOrEmpty(UserAgent))
                client.Headers.Add("user-agent", UserAgent);
            AdditionalHeaders.ForEach(h => client.Headers.Add(h));

            if (Proxy != null)
                client.Proxy = Proxy;

            return client;
        }

        public void Dispose()
        {
        }
        #endregion
    }
}

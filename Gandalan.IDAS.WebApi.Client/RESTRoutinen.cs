using Gandalan.IDAS.WebApi.Client;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Web
{
    /// <summary>
    /// Klasse für den HTTP-Datentransfer per REST an unsere WebAPIs. Ermöglicht das Senden
    /// und Empfangen von Objekten. Die Übermittlung erfolgt mit JSON serialisierten Objekten.
    /// </summary>
    public class RESTRoutinen : IDisposable
    {
        private readonly HttpClient _client;

        #region Constructors

        public RESTRoutinen(string baseUrl)
        {
            _client = HttpClientFactory.GetInstance(new HttpClientConfig()
            {
                BaseUrl = baseUrl
            });
        }

        public RESTRoutinen(string baseUrl, IWebProxy proxy)
        {
            _client = HttpClientFactory.GetInstance(new HttpClientConfig()
            {
                BaseUrl = baseUrl,
                Proxy = proxy
            });
        }

        public RESTRoutinen(HttpClientConfig config)
        {
            _client = HttpClientFactory.GetInstance(config);
        }

        #endregion Constructors

        public string UserAgent
        {
            set
            {
                _client.DefaultRequestHeaders.UserAgent.Clear();
                _client.DefaultRequestHeaders.UserAgent.TryParseAdd(value);
            }
        }

        #region public Methods

        /// <summary>
        /// Holt ein Objekt per HTTP GET
        /// </summary>
        /// <typeparam name="T">Typsierungsparameter</typeparam>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <param name="settings"></param>
        /// <returns>Objektinstanz</returns>
        public async Task<T> GetAsync<T>(string url, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(await GetAsync(url), settings);
        }

        public async Task<string> GetAsync(string url)
        {
            string contentAsString = null;
            HttpResponseMessage response = null;
            try
            {
                response = await _client.GetAsync(url);
                contentAsString = await response.Content?.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return contentAsString;
            }
            catch (Exception ex)
            {
                AddInfoToException(ex, url, GetCurrentMethodName(), response, contentAsString);
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        public async Task<byte[]> GetDataAsync(string url)
        {
            string contentAsString = null;
            HttpResponseMessage response = null;
            try
            {
                response = await _client.GetAsync(url);
                contentAsString = await response.Content?.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return await response.Content?.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                AddInfoToException(ex, url, GetCurrentMethodName(), response, contentAsString);
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        /// <summary>
        /// Sendet ein Objekt per HTTP POST an die angegebene URL, i.d.R. um es zu speichern
        /// </summary>
        /// <typeparam name="T">Typisierungsparameter</typeparam>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <param name="data">zu sendendes Objekt</param>
        /// <param name="settings"></param>
        /// <returns>deserialisierte Antwort (i.d.R. sollte das das gespeicherte Objekt in seiner Endfassung sein)</returns>
        public async Task<T> PostAsync<T>(string url, object data, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(await PostAsync(url, data, settings), settings);
        }

        public async Task<string> PostAsync(string url, object data, JsonSerializerSettings settings = null)
        {
            string contentAsString = null;
            HttpResponseMessage response = null;
            try
            {
                string json = JsonConvert.SerializeObject(data, settings);
                response = await _client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                contentAsString = await response.Content?.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return contentAsString;
            }
            catch (Exception ex)
            {
                AddInfoToException(ex, url, GetCurrentMethodName(), response, contentAsString);
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        public async Task<byte[]> PostDataAsync(string url, byte[] data)
        {
            string contentAsString = null;
            HttpResponseMessage response = null;
            try
            {
                response = await _client.PostAsync(url, new ByteArrayContent(data));
                contentAsString = await response.Content?.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return await response.Content?.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                AddInfoToException(ex, url, GetCurrentMethodName(), response, contentAsString);
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        /// <summary>
        /// Sendet ein Objekt per HTTP PUT an die angegebene URL, i.d.R. um es anzulegen
        /// </summary>
        /// <typeparam name="T">Typisierungsparameter</typeparam>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <param name="data">zu sendendes Objekt</param>
        /// <param name="settings"></param>
        /// <returns>deserialisierte Antwort (i.d.R. sollte das das gespeicherte Objekt in seiner Endfassung sein)</returns>
        public async Task<T> PutAsync<T>(string url, object data, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(await PutAsync(url, data, settings), settings);
        }

        public async Task<string> PutAsync(string url, object data, JsonSerializerSettings settings = null)
        {
            string contentAsString = null;
            HttpResponseMessage response = null;
            try
            {
                string json = JsonConvert.SerializeObject(data, settings);
                response = await _client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                contentAsString = await response.Content?.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return contentAsString;
            }
            catch (Exception ex)
            {
                AddInfoToException(ex, url, GetCurrentMethodName(), response, contentAsString);
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        public async Task<byte[]> PutDataAsync(string url, byte[] data)
        {
            string contentAsString = null;
            HttpResponseMessage response = null;
            try
            {
                response = await _client.PutAsync(url, new ByteArrayContent(data));
                contentAsString = await response.Content?.ReadAsStringAsync();
                return await response.Content?.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                AddInfoToException(ex, url, GetCurrentMethodName(), response, contentAsString);
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        /// <summary>
        /// Löscht ein Objekt per HTTP DELETE an die angegebene URL
        /// </summary>
        /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
        /// <returns>Antwort des Servers als String</returns>
        public async Task DeleteAsync(string url)
        {
            string contentAsString = null;
            HttpResponseMessage response = null;
            try
            {
                response = await _client.DeleteAsync(url);
                contentAsString = await response.Content?.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                AddInfoToException(ex, url, GetCurrentMethodName(), response, contentAsString);
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        public async Task<string> DeleteAsync(string url, object data, JsonSerializerSettings settings = null)
        {
            string contentAsString = null;
            HttpResponseMessage response = null;
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(_client.BaseAddress, url),
                    Content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json")
                };
                response = await _client.SendAsync(request);
                contentAsString = await response.Content?.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return await response.Content?.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                AddInfoToException(ex, url, GetCurrentMethodName(), response, contentAsString);
                // Für Diagnosezwecke wird hier gefangen und weitergeworfen
                throw;
            }
        }

        public async Task<T> DeleteAsync<T>(string url, object data, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(await DeleteAsync(url, data, settings), settings);
        }

        #endregion

        #region private Methods

        private static void AddInfoToException(Exception ex, string url, string callMethod, HttpResponseMessage response = null, string responseContent = null)
        {
            ex.Data.Add("URL", url);
            ex.Data.Add("CallMethod", callMethod);
            ex.Data.Add("StatusCode", response != null ? response.StatusCode : HttpStatusCode.InternalServerError);
            if (responseContent != null)
            {
                ex.Data.Add("Response", responseContent);
            }
        }

        public static string GetCurrentMethodName()
        {
            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(1);

            return stackFrame?.GetMethod()?.Name;
        }

        #endregion

        public void Dispose()
        {
        }
    }
}

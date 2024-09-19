using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client;
using Newtonsoft.Json;

namespace Gandalan.IDAS.Web;

/// <summary>
/// Klasse für den HTTP-Datentransfer per REST an unsere WebAPIs. Ermöglicht das Senden
/// und Empfangen von Objekten. Die Übermittlung erfolgt mit JSON serialisierten Objekten.
/// </summary>
public class RESTRoutinen : IDisposable
{
    private readonly HttpClientConfig _config;
    private readonly HttpClient _client;
    private readonly Dictionary<string, HttpClient> _versionClients = [];

    #region Constructors

    public RESTRoutinen(string baseUrl)
    {
        _client = HttpClientFactory.GetInstance(new HttpClientConfig { BaseUrl = baseUrl });
    }

    public RESTRoutinen(string baseUrl, IWebProxy proxy)
    {
        _client = HttpClientFactory.GetInstance(new HttpClientConfig
        {
            BaseUrl = baseUrl,
            Proxy = proxy
        });
    }

    public RESTRoutinen(HttpClientConfig config)
    {
        _config = config;
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
    /// <param name="version">API Version, if omitted, defaults to version 1.0</param>
    /// <returns>Objektinstanz</returns>
    public async Task<T> GetAsync<T>(string url, JsonSerializerSettings settings = null, string version = null)
    {
        return JsonConvert.DeserializeObject<T>(await GetAsync(url, version), settings);
    }

    public async Task<string> GetAsync(string url, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var client = GetClientByVersion(version);
            response = await client.GetAsync(url);
            contentAsString = await response.Content?.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return contentAsString;
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
            // Für Diagnosezwecke wird hier gefangen und weitergeworfen
            throw;
        }
    }

    public async Task<byte[]> GetDataAsync(string url, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var client = GetClientByVersion(version);
            response = await client.GetAsync(url);
            contentAsString = await response.Content?.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return await response.Content?.ReadAsByteArrayAsync();
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
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
    /// <param name="version">API Version, if omitted, defaults to version 1.0</param>
    /// <returns>deserialisierte Antwort (i.d.R. sollte das gespeicherte Objekt in seiner Endfassung sein)</returns>
    public async Task<T> PostAsync<T>(string url, object data, JsonSerializerSettings settings = null, string version = null)
    {
        return JsonConvert.DeserializeObject<T>(await PostAsync(url, data, settings, version: version), settings);
    }

    public async Task<string> PostAsync(string url, object data, JsonSerializerSettings settings = null, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var json = JsonConvert.SerializeObject(data, settings);
            var client = GetClientByVersion(version);
            response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            contentAsString = await response.Content?.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return contentAsString;
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
            throw;
        }
    }

    public async Task<byte[]> PostDataAsync(string url, byte[] data, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var client = GetClientByVersion(version);
            response = await client.PostAsync(url, new ByteArrayContent(data));
            contentAsString = await response.Content?.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return await response.Content?.ReadAsByteArrayAsync();
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
            throw;
        }
    }

    public async Task<byte[]> PostDataAsync(string url, HttpContent data, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var client = GetClientByVersion(version);
            response = await client.PostAsync(url, data);
            contentAsString = await response.Content?.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return await response.Content?.ReadAsByteArrayAsync();
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
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
    /// <param name="version">API Version, if omitted, defaults to version 1.0</param>
    /// <returns>deserialisierte Antwort (i.d.R. sollte das gespeicherte Objekt in seiner Endfassung sein)</returns>
    public async Task<T> PutAsync<T>(string url, object data, JsonSerializerSettings settings = null, string version = null)
    {
        return JsonConvert.DeserializeObject<T>(await PutAsync(url, data, settings, version: version), settings);
    }

    public async Task<string> PutAsync(string url, object data, JsonSerializerSettings settings = null, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var json = JsonConvert.SerializeObject(data, settings);
            var client = GetClientByVersion(version);
            response = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            contentAsString = await response.Content?.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return contentAsString;
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
            throw;
        }
    }

    public async Task<byte[]> PutDataAsync(string url, byte[] data, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var client = GetClientByVersion(version);
            response = await client.PutAsync(url, new ByteArrayContent(data));
            contentAsString = await response.Content?.ReadAsStringAsync();
            return await response.Content?.ReadAsByteArrayAsync();
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
            throw;
        }
    }

    public async Task<byte[]> PutDataAsync(string url, HttpContent data, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var client = GetClientByVersion(version);
            response = await client.PutAsync(url, data);
            contentAsString = await response.Content?.ReadAsStringAsync();
            return await response.Content?.ReadAsByteArrayAsync();
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
            throw;
        }
    }

    /// <summary>
    /// Löscht ein Objekt per HTTP DELETE an die angegebene URL
    /// </summary>
    /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
    /// <param name="version">API Version, if omitted, defaults to version 1.0</param>
    /// <returns>Antwort des Servers als String</returns>
    public async Task DeleteAsync(string url, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var client = GetClientByVersion(version);
            response = await client.DeleteAsync(url);
            contentAsString = await response.Content?.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
            throw;
        }
    }

    public async Task<string> DeleteAsync(string url, object data, JsonSerializerSettings settings = null, string version = null)
    {
        string contentAsString = null;
        HttpResponseMessage response = null;
        try
        {
            var client = GetClientByVersion(version);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(client.BaseAddress, url),
                Content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json")
            };

            response = await client.SendAsync(request);
            contentAsString = await response.Content?.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return await response.Content?.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            AddInfoToException(ex, url, response, contentAsString);
            throw;
        }
    }

    public async Task<T> DeleteAsync<T>(string url, object data, JsonSerializerSettings settings = null, string version = null)
    {
        return JsonConvert.DeserializeObject<T>(await DeleteAsync(url, data, settings, version: version), settings);
    }

    #endregion

    #region private Methods

    private static void AddInfoToException(Exception ex, string url, HttpResponseMessage response = null, string responseContent = null, [CallerMemberName] string sender = null)
    {
        ex.Data.Add("URL", url);
        ex.Data.Add("CallMethod", sender);
        ex.Data.Add("StatusCode", response?.StatusCode ?? HttpStatusCode.InternalServerError);
        if (!string.IsNullOrWhiteSpace(responseContent))
        {
            ex.Data.Add("Response", responseContent);
        }
    }

    #endregion

    public void Dispose()
    {
    }

    public HttpClient GetClientByVersion(string version = null)
    {
        if (version == null || _config == null)
        {
            return _client;
        }

        if (!_versionClients.TryGetValue(version, out var versionClient))
        {
            var config = (HttpClientConfig)_config.Clone();
            config.AdditionalHeaders.Add("api-version", version);

            _versionClients.Add(version, HttpClientFactory.GetInstance(config));
            return _versionClients[version];
        }

        return versionClient;
    }
}

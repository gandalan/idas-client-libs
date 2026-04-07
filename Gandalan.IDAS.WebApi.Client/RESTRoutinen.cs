using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
    private readonly ConcurrentDictionary<string, HttpClient> _versionClients = new();

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

    /// <summary>
    /// Setting the UserAgent on a shared <see cref="HttpClient"/> is not thread-safe.
    /// Configure the UserAgent via <see cref="HttpClientConfig.UserAgent"/> instead.
    /// </summary>
    [Obsolete("Setting UserAgent on a shared HttpClient is not thread-safe. Use HttpClientConfig.UserAgent instead.")]
    public string UserAgent
    {
        set
        {
            _client.DefaultRequestHeaders.UserAgent.Clear();
            _client.DefaultRequestHeaders.UserAgent.TryParseAdd(value);
        }
    }

    private volatile Dictionary<string, string> _perRequestHeaders;

    /// <summary>
    /// Replaces the set of headers that are added to every outgoing request (e.g. auth headers).
    /// Thread-safe via an atomic reference swap — in-flight requests use the previous snapshot.
    /// </summary>
    internal void UpdatePerRequestHeaders(Dictionary<string, string> headers)
    {
        _perRequestHeaders = headers != null ? new Dictionary<string, string>(headers) : null;
    }

    #region public Methods

    /// <summary>
    /// Holt ein Objekt per HTTP GET
    /// </summary>
    /// <typeparam name="T">Typisierungsparameter</typeparam>
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
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Get, url);
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<byte[]> GetDataAsync(string url, string version = null)
    {
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Get, url);
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsByteArrayAsync();
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
        var json = JsonConvert.SerializeObject(data, settings);
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Post, url);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<byte[]> PostDataAsync(string url, byte[] data, string version = null)
    {
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Post, url);
        request.Content = new ByteArrayContent(data);
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsByteArrayAsync();
    }

    public async Task<byte[]> PostDataAsync(string url, HttpContent data, string version = null)
    {
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Post, url);
        request.Content = data;
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsByteArrayAsync();
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
        var json = JsonConvert.SerializeObject(data, settings);
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Put, url);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<byte[]> PutDataAsync(string url, byte[] data, string version = null)
    {
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Put, url);
        request.Content = new ByteArrayContent(data);
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsByteArrayAsync();
    }

    public async Task<byte[]> PutDataAsync(string url, HttpContent data, string version = null)
    {
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Put, url);
        request.Content = data;
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsByteArrayAsync();
    }

    /// <summary>
    /// Löscht ein Objekt per HTTP DELETE an die angegebene URL
    /// </summary>
    /// <param name="url">Relative URL, bezogen auf die BaseUrl</param>
    /// <param name="version">API Version, if omitted, defaults to version 1.0</param>
    /// <returns>Antwort des Servers als String</returns>
    public async Task DeleteAsync(string url, string version = null)
    {
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Delete, url);
        await client.SendAsync(request);
    }

    public async Task<string> DeleteAsync(string url, object data, JsonSerializerSettings settings = null, string version = null)
    {
        var client = GetClientByVersion(version);
        var request = BuildRequestMessage(HttpMethod.Delete, url);
        request.Content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<T> DeleteAsync<T>(string url, object data, JsonSerializerSettings settings = null, string version = null)
    {
        return JsonConvert.DeserializeObject<T>(await DeleteAsync(url, data, settings, version: version), settings);
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

        return _versionClients.GetOrAdd(version, v =>
        {
            var config = (HttpClientConfig)_config.Clone();
            config.AdditionalHeaders.Add("api-version", v);
            return HttpClientFactory.GetInstance(config);
        });
    }

    /// <summary>
    /// Builds an <see cref="HttpRequestMessage"/> and applies per-request headers
    /// (auth) without mutating the shared <see cref="HttpClient.DefaultRequestHeaders"/>.
    /// </summary>
    private HttpRequestMessage BuildRequestMessage(HttpMethod method, string url)
    {
        var request = new HttpRequestMessage(method, url);

        var perRequest = _perRequestHeaders; // single volatile read for consistency
        if (perRequest != null)
        {
            foreach (var kvp in perRequest)
                request.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value);
        }

        return request;
    }
}

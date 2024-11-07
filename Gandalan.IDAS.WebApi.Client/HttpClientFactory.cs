using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Gandalan.IDAS.WebApi.Client;

public class HttpClientConfig : ICloneable
{
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
    public Dictionary<string, string> AdditionalHeaders { get; private set; } = [];

    public ICredentials Credentials { get; set; }

    /// <summary>
    /// User-Agent Header. Wird bei jeder Anfrage mitgeschickt.
    /// </summary>
    public string UserAgent { get; set; }

    /// <summary>
    /// AcceptEncoding Header wird auf GZIP gesetzt.
    /// </summary>
    public bool UseCompression { get; set; }

    public object Clone()
    {
        return new HttpClientConfig
        {
            BaseUrl = BaseUrl,
            Proxy = Proxy,
            Credentials = Credentials,
            UserAgent = UserAgent,
            UseCompression = UseCompression,
            AdditionalHeaders = new Dictionary<string, string>(AdditionalHeaders)
        };
    }

    public override bool Equals(object obj)
    {
        if (obj is not HttpClientConfig other) return false;

        // Compare base properties
        if (BaseUrl != other.BaseUrl ||
            UseCompression != other.UseCompression ||
            UserAgent != other.UserAgent ||
            !Equals(Credentials, other.Credentials) ||
            !Equals(Proxy, other.Proxy))
        {
            return false;
        }

        // Compare headers
        if (AdditionalHeaders.Count != other.AdditionalHeaders.Count)
        {
            return false;
        }

        foreach (var pair in AdditionalHeaders)
        {
            if (!other.AdditionalHeaders.TryGetValue(pair.Key, out var value) || value != pair.Value)
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        // Hash each property and combine them to generate a unique hash
        var hash = BaseUrl.GetHashCode() ^ UseCompression.GetHashCode() ^ (UserAgent?.GetHashCode() ?? 0);
        if (Credentials != null)
        {
            hash ^= Credentials.GetHashCode();
        }
        if (Proxy != null)
        {
            hash ^= Proxy.GetHashCode();
        }
        foreach (var header in AdditionalHeaders)
        {
            hash ^= header.Key.GetHashCode() ^ header.Value.GetHashCode();
        }
        return hash;
    }
}

public class HttpClientFactory
{
    private static readonly ConcurrentDictionary<HttpClientConfig, HttpClient> _clients = new();

    private HttpClientFactory()
    {
    }

    public static HttpClient GetInstance(HttpClientConfig config)
    {
        // Check if an instance already exists to avoid unnecessary creation
        if (_clients.TryGetValue(config, out var client))
        {
            return client;
        }

        // Try to add a new client; only one thread will succeed in adding
        var newClient = createWebClient(config);
        if (_clients.TryAdd(config, newClient))
        {
            return newClient;
        }
        else
        {
            // Dispose the newly created client if another thread added a client first
            newClient.Dispose();
        }

        // Retrieve the existing client from the dictionary
        _clients.TryGetValue(config, out client);
        return client;
    }

    /// <summary>
    /// Erstellt und konfiguriert eine neue WebClient-Instanz
    /// </summary>
    private static HttpClient createWebClient(HttpClientConfig config)
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = config.UseCompression ? DecompressionMethods.GZip | DecompressionMethods.Deflate : DecompressionMethods.None,
            Credentials = config.Credentials,
            Proxy = config.Proxy
        };

        var client = new HttpClient(handler);
        client.BaseAddress = new Uri(config.BaseUrl);
        client.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.Timeout = new TimeSpan(0, 5, 0); // 5 Minute

        if (!string.IsNullOrEmpty(config.UserAgent))
        {
            client.DefaultRequestHeaders.UserAgent.TryParseAdd(config.UserAgent);
        }

        foreach (var key in config.AdditionalHeaders.Keys)
        {
            client.DefaultRequestHeaders.Add(key, config.AdditionalHeaders[key]);
        }

        return client;
    }
}

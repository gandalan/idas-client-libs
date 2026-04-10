using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using Gandalan.IDAS.WebApi.Client.Handlers;

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

    /// <summary>
    /// Gets or sets the collection of URLs that opt-in for new API redirects.
    /// </summary>
    public string[] NewApiOptInUrls { get; set; }

    /// <summary>
    /// Maximum number of concurrent TCP connections per server endpoint.
    /// On .NET Framework 4.8, <see cref="System.Net.HttpWebRequest"/> routes through
    /// <see cref="System.Net.ServicePointManager"/> which defaults to 2 — far too low
    /// for applications making parallel API calls. This property raises that limit.
    /// On .NET 8+, <c>SocketsHttpHandler</c> already uses <see cref="int.MaxValue"/> internally.
    /// </summary>
    public int MaxConnectionsPerServer { get; set; } = 30;

    public object Clone()
    {
        return new HttpClientConfig
        {
            BaseUrl = BaseUrl,
            Proxy = Proxy,
            Credentials = Credentials,
            UserAgent = UserAgent,
            UseCompression = UseCompression,
            AdditionalHeaders = new Dictionary<string, string>(AdditionalHeaders),
            NewApiOptInUrls = NewApiOptInUrls,
            MaxConnectionsPerServer = MaxConnectionsPerServer
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

        // Compare NewApiOptInUrls
        if (!NullableSequenceEqual(NewApiOptInUrls, other.NewApiOptInUrls))
            return false;

        if (MaxConnectionsPerServer != other.MaxConnectionsPerServer)
            return false;

        return true;
    }

    private static bool NullableSequenceEqual(string[] a, string[] b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.SequenceEqual(b, StringComparer.Ordinal);
    }

    public override int GetHashCode()
    {
        // NOTE: HttpClientConfig is used as a dictionary key and must not be mutated
        // after being added to a dictionary. Properties are mutable by design for
        // construction convenience, but treat instances as effectively immutable once in use.
#if NETFRAMEWORK
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + (BaseUrl?.GetHashCode() ?? 0);
            hash = hash * 31 + UseCompression.GetHashCode();
            hash = hash * 31 + (UserAgent != null ? StringComparer.Ordinal.GetHashCode(UserAgent) : 0);
            hash = hash * 31 + (Credentials?.GetHashCode() ?? 0);
            hash = hash * 31 + (Proxy?.GetHashCode() ?? 0);
            foreach (var header in AdditionalHeaders)
            {
                hash = hash * 31 + StringComparer.Ordinal.GetHashCode(header.Key);
                hash = hash * 31 + StringComparer.Ordinal.GetHashCode(header.Value);
            }
            if (NewApiOptInUrls != null)
            {
                foreach (var url in NewApiOptInUrls)
                    hash = hash * 31 + (url != null ? StringComparer.Ordinal.GetHashCode(url) : 0);
            }
            hash = hash * 31 + MaxConnectionsPerServer.GetHashCode();
            return hash;
        }
#else
        var hash = new HashCode();
        hash.Add(BaseUrl);
        hash.Add(UseCompression);
        hash.Add(UserAgent, StringComparer.Ordinal);
        hash.Add(Credentials);
        hash.Add(Proxy);
        foreach (var header in AdditionalHeaders)
        {
            hash.Add(header.Key, StringComparer.Ordinal);
            hash.Add(header.Value, StringComparer.Ordinal);
        }
        if (NewApiOptInUrls != null)
        {
            foreach (var url in NewApiOptInUrls)
                hash.Add(url, StringComparer.Ordinal);
        }
        hash.Add(MaxConnectionsPerServer);
        return hash.ToHashCode();
#endif
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

        // Dispose the newly created client if another thread added a client first
        newClient.Dispose();

        // Retrieve the existing client from the dictionary
        _clients.TryGetValue(config, out client);
        return client;
    }

    /// <summary>
    /// Erstellt und konfiguriert eine neue WebClient-Instanz
    /// </summary>
    private static HttpClient createWebClient(HttpClientConfig config)
    {
        // Build the DelegatingHandler pipeline:
        // ErrorEnrichmentHandler → GatewayClusterHandler → HttpClientHandler
        HttpMessageHandler pipeline = new HttpClientHandler
        {
            AutomaticDecompression = config.UseCompression ? DecompressionMethods.GZip | DecompressionMethods.Deflate : DecompressionMethods.None,
            Credentials = config.Credentials,
            Proxy = config.Proxy
        };

#if NETFRAMEWORK
        // .NET Framework routes HttpClient through ServicePointManager, which caps
        // concurrent TCP connections per host at 2 by default. Raise it explicitly
        // so parallel API calls are not serialised at the socket level.
        if (Uri.TryCreate(config.BaseUrl, UriKind.Absolute, out var baseUri))
        {
            ServicePointManager.FindServicePoint(baseUri).ConnectionLimit = config.MaxConnectionsPerServer;
        }
#endif

        pipeline = new GatewayClusterHandler(config.NewApiOptInUrls) { InnerHandler = pipeline };
        pipeline = new ErrorEnrichmentHandler { InnerHandler = pipeline };

        var client = new HttpClient(pipeline);
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

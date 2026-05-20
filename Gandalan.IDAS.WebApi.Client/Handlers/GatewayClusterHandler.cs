using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Adds the <c>X-Gateway-Cluster</c> header to outgoing requests whose URI path
/// matches one of the configured opt-in endpoints for the new IDAS API backend.
/// Configured per <see cref="HttpClient"/> via <see cref="HttpClientConfig.NewApiOptInUrls"/>.
/// </summary>
internal sealed class GatewayClusterHandler : DelegatingHandler
{
    private readonly string[] _newApiOptInUrls;

    internal GatewayClusterHandler(string[] newApiOptInUrls)
    {
        _newApiOptInUrls = newApiOptInUrls;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (_newApiOptInUrls != null && _newApiOptInUrls.Length > 0)
        {
            var uriPath = request.RequestUri?.AbsolutePath;
            if (uriPath != null && _newApiOptInUrls.Any(endpoint => IsPathMatchingEndpoint(uriPath, endpoint)))
            {
                request.Headers.TryAddWithoutValidation("X-Gateway-Cluster", "idas");
            }
        }

        return base.SendAsync(request, cancellationToken);
    }

    /// <summary>
    /// Determines whether the specified URI path matches the given configured endpoint,
    /// using a case-insensitive comparison and ensuring a valid path boundary.
    /// </summary>
    /// <param name="uriPath">The URI path to evaluate against the endpoint.</param>
    /// <param name="endpoint">The endpoint to match at the start of the URI path. Trailing slashes are ignored. Cannot be null.</param>
    /// <returns>true if the URI path starts with the endpoint and the match occurs at a valid path boundary; otherwise, false.</returns>
    internal static bool IsPathMatchingEndpoint(string uriPath, string endpoint)
    {
        if (endpoint == null) return false;

        var normalizedEndpoint = endpoint.TrimEnd('/');

        return uriPath.StartsWith(normalizedEndpoint, StringComparison.OrdinalIgnoreCase)
            && HasValidPathBoundary(uriPath, normalizedEndpoint.Length);
    }

    /// <summary>
    /// Determines whether the specified endpoint length is at a valid boundary within the given URI path.
    /// Configured endpoint paths should only match complete segments of the URI path:
    /// We want to hit /api/Login if it's configured not /api/LoginJwt
    /// </summary>
    /// <param name="uriPath">The URI path to evaluate. Cannot be null.</param>
    /// <param name="endpointLength">The position within the URI path to check for a valid boundary.</param>
    /// <returns>true if the endpoint length is at the end of the URI path or is immediately followed by a '/' or '?'; otherwise, false.</returns>
    internal static bool HasValidPathBoundary(string uriPath, int endpointLength)
        => endpointLength >= uriPath.Length
            || uriPath[endpointLength] == '/'
            || uriPath[endpointLength] == '?';
}

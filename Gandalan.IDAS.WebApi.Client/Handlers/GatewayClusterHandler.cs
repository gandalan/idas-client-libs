using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Sends <c>X-Gateway-Cluster: legacy</c> on every request when <see cref="HttpClientConfig.ForceLegacyApi"/> is set,
/// so the gateway routes it to the legacy API even where the new API is its default.
/// Without the flag the gateway alone decides the backend.
/// </summary>
internal sealed class GatewayClusterHandler : DelegatingHandler
{
    private const string X_GATEWAY_CLUSTER = "X-Gateway-Cluster";

    private readonly bool _forceLegacyApi;

    internal GatewayClusterHandler(bool forceLegacyApi)
    {
        _forceLegacyApi = forceLegacyApi;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (_forceLegacyApi)
        {
            request.Headers.TryAddWithoutValidation(X_GATEWAY_CLUSTER, "legacy");
        }

        return base.SendAsync(request, cancellationToken);
    }
}

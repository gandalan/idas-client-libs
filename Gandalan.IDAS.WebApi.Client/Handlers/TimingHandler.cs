using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Misst die Dauer jedes Requests und meldet sie an den <see cref="HttpTimingMonitor"/>, auch wenn der Request abbricht.
/// Sitzt innerhalb des <see cref="ErrorEnrichmentHandler"/>, damit er die Antwort sieht, bevor dieser bei Nicht-Erfolg wirft.
/// </summary>
public sealed class TimingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var stoppuhr = Stopwatch.StartNew();
        try
        {
            var response = await base.SendAsync(request, cancellationToken);
            HttpTimingMonitor.Observe(request, response, stoppuhr.ElapsedMilliseconds, null);
            return response;
        }
        catch (Exception ex)
        {
            HttpTimingMonitor.Observe(request, null, stoppuhr.ElapsedMilliseconds, ex);
            throw;
        }
    }
}

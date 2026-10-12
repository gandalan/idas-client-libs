using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Gandalan.IDAS.Logging;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Misst jeden Request bis zum vollständig gelesenen Antwort-Body und meldet ihn an den <see cref="HttpTimingMonitor"/>,
/// auch wenn der Request abbricht. Ohne Zuhörer reicht er den Request unverändert durch.
/// Sitzt innerhalb des <see cref="ErrorEnrichmentHandler"/>, damit er die Antwort sieht, bevor dieser bei Nicht-Erfolg wirft.
/// </summary>
public sealed class TimingHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!HttpTimingMonitor.HatZuhoerer)
            return base.SendAsync(request, cancellationToken);

        return messeAsync(request, cancellationToken);
    }

    private async Task<HttpResponseMessage> messeAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var stoppuhr = Stopwatch.StartNew();
        HttpResponseMessage response;
        try
        {
            response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            HttpTimingMonitor.Observe(request, null, stoppuhr.ElapsedMilliseconds, 0, ex);
            throw;
        }

        beobachteBody(request, response, stoppuhr);
        return response;
    }

    private static void beobachteBody(HttpRequestMessage request, HttpResponseMessage response, Stopwatch stoppuhr)
    {
        if (response.Content == null)
        {
            HttpTimingMonitor.Observe(request, response, stoppuhr.ElapsedMilliseconds, 0, null);
            return;
        }

        try
        {
            response.Content = new ZaehlenderHttpContent(response.Content, request, response, stoppuhr);
        }
        catch (Exception ex)
        {
            L.Fehler(ex, "TimingHandler konnte den Antwort-Body nicht zur Messung umhüllen");
        }
    }
}

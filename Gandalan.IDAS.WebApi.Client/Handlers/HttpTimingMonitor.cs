using System;
using System.Linq;
using System.Net.Http;

using Gandalan.IDAS.Logging;
using Gandalan.IDAS.WebApi.Client.Constants;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Meldet prozessweit jeden abgeschlossenen HTTP-Request mit Dauer, Bytes, Status und Gateway-Backend.
/// Gefüttert vom <see cref="TimingHandler"/> für jede Antwort und jeden abgebrochenen Request.
/// Ohne Zuhörer wird nichts gebaut; eigene Fehler und Fehler der Zuhörer werden nur geloggt, damit der Request nie gestört wird.
/// </summary>
public static class HttpTimingMonitor
{
    /// <summary>
    /// Wird nach jedem Request ausgelöst. Läuft auf dem Thread, der den Antwort-Body liest bzw. verwirft.
    /// </summary>
    public static event Action<HttpTimingInfo> RequestAbgeschlossen;

    public static bool HatZuhoerer => RequestAbgeschlossen != null;

    public static void Observe(HttpRequestMessage request, HttpResponseMessage response, long dauerMs, long bytes, Exception fehler)
    {
        var zuhoerer = RequestAbgeschlossen;
        if (zuhoerer == null)
            return;

        try
        {
            benachrichtige(zuhoerer, erstelleInfo(request, response, dauerMs, bytes, fehler));
        }
        catch (Exception ex)
        {
            L.Fehler(ex, "HttpTimingMonitor konnte den Request nicht melden");
        }
    }

    private static HttpTimingInfo erstelleInfo(HttpRequestMessage request, HttpResponseMessage response, long dauerMs, long bytes, Exception fehler)
        => new(
            request?.Method.Method,
            request?.RequestUri,
            (int?)response?.StatusCode,
            dauerMs,
            bytes,
            leseHeader(response, ApiHeaderNames.GatewayBackend),
            leseHeader(response, ApiHeaderNames.OperationId),
            beschreibe(fehler),
            DateTimeOffset.UtcNow);

    private static string leseHeader(HttpResponseMessage response, string headerName)
    {
        if (response == null || !response.Headers.TryGetValues(headerName, out var values))
            return null;

        return values.FirstOrDefault();
    }

    private static string beschreibe(Exception fehler)
        => fehler == null ? null : $"{fehler.GetType().Name}: {fehler.Message}";

    private static void benachrichtige(Action<HttpTimingInfo> zuhoerer, HttpTimingInfo info)
    {
        foreach (Action<HttpTimingInfo> einzelner in zuhoerer.GetInvocationList())
        {
            try
            {
                einzelner(info);
            }
            catch (Exception ex)
            {
                L.Fehler(ex, "Zuhörer des HttpTimingMonitor ist fehlgeschlagen");
            }
        }
    }
}

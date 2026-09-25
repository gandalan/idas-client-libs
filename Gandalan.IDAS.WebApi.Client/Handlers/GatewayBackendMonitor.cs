using System;
using System.Linq;
using System.Net.Http;

using Gandalan.IDAS.WebApi.Client.Constants;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Merkt sich prozessweit, welche Backends laut Gateway-Header <c>X-Gateway-Backend</c> bisher geantwortet haben.
/// Das Gateway routet pro Pfad, deshalb zählt die Menge der gesehenen Backends, nicht die letzte Antwort.
/// Gefüttert vom <see cref="ErrorEnrichmentHandler"/> für jede Antwort (Erfolg und Fehler).
/// </summary>
public static class GatewayBackendMonitor
{
    private const int New = 1;
    private const int Legacy = 2;

    private static readonly object _lock = new();
    private static int _seen;

    /// <summary>
    /// Wird ausgelöst, sobald ein bisher ungesehenes Backend antwortet. Läuft auf dem Thread des HTTP-Aufrufs.
    /// </summary>
    public static event Action Changed;

    /// <summary>
    /// "new", "legacy", "gemischt" oder null, solange keine Antwort den Header trug (z.B. Gateway ohne Header, andere Hosts).
    /// </summary>
    public static string Anzeige
    {
        get
        {
            lock (_lock)
            {
                return _seen switch { New => "new", Legacy => "legacy", New | Legacy => "gemischt", _ => null };
            }
        }
    }

    public static void Observe(HttpResponseMessage response)
    {
        if (response == null || !response.Headers.TryGetValues(ApiHeaderNames.GatewayBackend, out var values))
            return;

        var bit = values.FirstOrDefault() switch { "new" => New, "legacy" => Legacy, _ => 0 };
        if (bit == 0)
            return;

        lock (_lock)
        {
            if ((_seen & bit) != 0)
                return;
            _seen |= bit;
        }

        Changed?.Invoke();
    }

    /// <summary>
    /// Vergisst alle gesehenen Backends (für Tests).
    /// </summary>
    public static void Reset()
    {
        lock (_lock)
        {
            _seen = 0;
        }
    }
}

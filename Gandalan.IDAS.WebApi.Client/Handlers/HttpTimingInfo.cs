using System;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Messwerte eines abgeschlossenen HTTP-Requests, geliefert vom <see cref="HttpTimingMonitor"/>.
/// Enthält bewusst weder Header noch Bodies.
/// Eigenschaften nur mit <c>get</c>, weil net48 kein <c>init</c> ohne Polyfill kennt.
/// </summary>
public sealed record HttpTimingInfo(
    string Methode,
    Uri Url,
    int? Status,
    long DauerMs,
    long Bytes,
    string GatewayBackend,
    string OperationId,
    string Fehler,
    DateTimeOffset Zeitpunkt)
{
    public string Methode { get; } = Methode;
    public Uri Url { get; } = Url;
    public int? Status { get; } = Status;

    /// <summary>
    /// Dauer vom Absenden bis der Antwort-Body vollständig gelesen ist, bzw. bis zum Abbruch oder Verwerfen des ungelesenen Bodys.
    /// </summary>
    public long DauerMs { get; } = DauerMs;

    /// <summary>
    /// Tatsächlich gelesene Body-Bytes nach Dekompression; 0, wenn der Body nie gelesen wurde.
    /// </summary>
    public long Bytes { get; } = Bytes;

    public string GatewayBackend { get; } = GatewayBackend;
    public string OperationId { get; } = OperationId;
    public string Fehler { get; } = Fehler;
    public DateTimeOffset Zeitpunkt { get; } = Zeitpunkt;
}

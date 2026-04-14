using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Request-Body für RunKapBerechnungWithCallback (Einzel):
/// Enthält die Callback-URL, an die das Backend das Ergebnis zurücksendet.
/// </summary>
public class KapBerechnungCallbackRequest
{
  public string CallbackUrl { get; set; }
}

/// <summary>
/// Ergebnis, das das Backend per POST an die Callback-URL sendet,
/// sobald die Kapazitätsberechnung abgeschlossen (oder fehlgeschlagen) ist.
/// </summary>
public class KapBerechnungCallbackResult
{
  public Guid PositionGuid { get; set; }
  public long MandantId { get; set; }
  public bool Success { get; set; }
  public string Error { get; set; }
  public long DurationMs { get; set; }
}

/// <summary>
/// Request-Body für RunKapBerechnungBatchWithCallback:
/// Liste von Positionen + Callback-URL.
/// </summary>
public class KapBerechnungBatchCallbackRequest
{
  public List<KapBerechnungPosition> Positions { get; set; }
  public string CallbackUrl { get; set; }
}

/// <summary>
/// Einzelne Position innerhalb eines Batch-Requests.
/// </summary>
public class KapBerechnungPosition
{
  public Guid PositionGuid { get; set; }
  public long MandantId { get; set; }
}

/// <summary>
/// Aggregiertes Batch-Ergebnis, das per POST an die Callback-URL gesendet wird,
/// sobald alle Positionen verarbeitet wurden.
/// </summary>
public class KapBerechnungBatchCallbackResult
{
  public List<KapBerechnungCallbackResult> Results { get; set; }
  public int TotalCount { get; set; }
  public int SuccessCount { get; set; }
  public int FailCount { get; set; }
  public long TotalDurationMs { get; set; }
}

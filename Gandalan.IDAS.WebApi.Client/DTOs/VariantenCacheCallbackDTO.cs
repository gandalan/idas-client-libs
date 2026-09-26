namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Request-Body für StartCacheWebJobWithCallback:
/// Enthält die Callback-URL, an die das Backend das Ergebnis zurücksendet.
/// </summary>
public class VariantenCacheCallbackRequest
{
  public string CallbackUrl { get; set; }
}

/// <summary>
/// Ergebnis, das das Backend per POST an die Callback-URL sendet,
/// sobald der VariantenListe-CacheWebJob abgeschlossen ist.
/// </summary>
public class VariantenCacheCallbackResult
{
  public bool Success { get; set; }
  public string Error { get; set; }
  public long DurationMs { get; set; }
}

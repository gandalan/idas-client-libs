using System;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// DTO für eine Lagerbuchung
/// </summary>
public class LagerbuchungDTO
{
    public Guid KatalogArtikelGuid { get; set; }
    [Obsolete("FarbKuerzelGuid verwenden")]
    public Guid FarbGuid { get; set; }
    public Guid FarbKuerzelGuid { get; set; }
    public float Betrag { get; set; }
    public bool IstReservierung { get; set; }
    public string Einheit { get; set; }
    public string Hinweis { get; set; }
    public string ArtosUser { get; set; }
    public string WindowsUser { get; set; }
    public DateTime ChangedDate { get; set; }
    public decimal BestandAlt { get; set; }
    public decimal BestandNeu { get; set; }
}

using System;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// DTO für die Lagerverwaltung
/// </summary>
public class LagerbestandDTO
{
    public Guid LagerbestandGuid { get; set; }
    public Guid KatalogArtikelGuid { get; set; }
    public string KatalogNummer { get; set; }
    [Obsolete("FarbKuerzelGuid verwenden")]
    public Guid FarbGuid { get; set; }
    public Guid FarbKuerzelGuid { get; set; }
    public string FarbKuerzel { get; set; }
    public decimal Lagerbestand { get; set; }
    public decimal Bestellbestand { get; set; }
    public decimal Mindestbestand { get; set; }
    public decimal Reserviert { get; set; }
    public decimal Maximalbestand { get; set; }
    public decimal EisernerBestand { get; set; }
    public string Einheit { get; set; }
    public string Lagerplatz { get; set; }
    public string Charge { get; set; }
    public bool IstAktiv { get; set; }
    public string Seriennummer { get; set; }
    public DateTime ChangedDate { get; set; }
    public string WindowsUser { get; set; }
}

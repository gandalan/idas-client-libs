using System;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Kompakte Darstellung eines Belegs für Listenansichten und Auswertungen.
/// Enthält die wichtigsten Beleg- und Vorgangsinformationen sowie Saldenwerte.
/// </summary>
public class BelegListDTO
{
    public int VorgangsNummer { get; set; }
    public string Kundenname { get; set; } = string.Empty;
    public string KundenNummer { get; set; } = string.Empty;
    public string BelegArt { get; set; } = string.Empty;
    public int BelegNummer { get; set; }
    public int BelegJahr { get; set; }
    public DateTime BelegDatum { get; set; }
    public int AnzahlPositionen { get; set; }
    public decimal Warenwert { get; set; }
    public decimal RabatteAufschlaege { get; set; }
    public decimal Transportkosten { get; set; }
    public decimal Mehrwertsteuer { get; set; }
    public decimal EndbetragBrutto { get; set; }
    public decimal GesamtbetragNetto { get; set; }
    public Guid VorgangGuid { get; set; }
    public Guid BelegGuid { get; set; }
    public bool IstArchiviert { get; set; }
}

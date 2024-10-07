using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class BearbeitungDTO
{
    public Guid BearbeitungGuid { get; set; }

    /// <summary>
    /// Eindeutiges Kennzeichen der Bearbeitung (aus GUID)
    /// </summary>
    public string Kennzeichen { get; set; }

    /// <summary>
    /// Ziel der Bearbeitung
    /// </summary>
    public Guid ZielKennzeichen { get; set; }

    /// <summary>
    /// Artikelbezeichnung
    /// </summary>
    public string BearbeitungsName { get; set; }

    /// <summary>
    /// Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt
    /// sich aus mit Laufmeter!)
    /// </summary>
    public decimal X { get; set; }

    /// <summary>
    /// Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt
    /// sich aus mit Stückzahl!)
    /// </summary>
    public decimal Y { get; set; }

    public string ProfilName { get; set; }
    public decimal ProfilLaenge { get; set; }
    public decimal ProfilBreite { get; set; }
    public string KatalogNummer { get; set; }
    public string StammdatenDateiFuerBearbeitung { get; set; }
    public string Spannsituation { get; set; }
    public string SpannSituationAlternativ { get; set; }
    public string StartXRegel { get; set; }
    public string FraesBild { get; set; }
    public string TextHP { get; set; }
    public string TextNP { get; set; }
    public decimal LLBreite { get; set; }
    public decimal LLBreiteAmBildschirm { get; set; }
    public decimal LLHoehe { get; set; }
    public decimal DurchmesserBohrung { get; set; }
    public decimal LochAbstand { get; set; }
    public decimal LochAbstandAmBildschirm { get; set; }
    public decimal Winkel { get; set; }
    public bool ManuellGeloescht { get; set; }
    public bool Passiv { get; set; }
    public bool NichtFreigegeben { get; set; }
    public bool MassXEditierbar { get; set; }
    public bool GroesseEditierbar { get; set; }
}

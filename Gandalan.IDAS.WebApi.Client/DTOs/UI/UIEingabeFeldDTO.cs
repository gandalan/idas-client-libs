using System;
using Gandalan.IDAS.WebApi.Client.Contracts;

namespace Gandalan.IDAS.WebApi.DTO;

public class UIEingabeFeldDTO : IWithGueltigkeitsZeitraum
{
    public int Reihenfolge { get; set; }
    public string Caption { get; set; }
    public string Tag { get; set; }
    public string Regel { get; set; }
    public double MinWert { get; set; }
    public bool MinWertWeichPruefen { get; set; }
    public double MaxWert { get; set; }
    public bool MaxWertWeichPruefen { get; set; }
    public string VorgabeWert { get; set; }
    public string HilfeText { get; set; }
    public string WarnText { get; set; }
    public string FehlerText { get; set; }
    public string WerteListeName { get; set; }
    public bool PreisFeldAnzeigen { get; set; }
    public int MindestBreite { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
    public Guid UIEingabeFeldGuid { get; set; }
    public string BelegBlattText { get; set; }
    public string AngebotsText { get; set; }
    public int EingabeLevel { get; set; }
    public int? ZusatzFeldGruppeId { get; set; }
    public int? GehoertZuZusatzFeldGruppeId { get; set; }
    public DateTime? GueltigAb { get; set; }
    public DateTime? GueltigBis { get; set; }
    public bool IstKonfiguratorFeld { get; set; }
}

public enum UIEingabeFeldRegelNames
{
    Unbekannt = 0,
    Frei = 1,
    NurGanzZahlen = 2,
    NurZahlen = 4,
    NurListenWerte = 8,
    NichtLeer = 16,
    Vierfachauswahl = 32,
    LangText = 64,
    ArtikelFarbe = 128,
}

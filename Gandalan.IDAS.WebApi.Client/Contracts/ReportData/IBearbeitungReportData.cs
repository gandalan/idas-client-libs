using System;

namespace Gandalan.IDAS.WebApi.Client.Contracts.ReportData
{
    public interface IBearbeitungReportData
    {
        Guid BearbeitungGuid { get; set; }
        string Kennzeichen { get; set; }
        Guid ZielKennzeichen { get; set; }
        string BearbeitungsName { get; set; }
        decimal X { get; set; }
        decimal Y { get; set; }
        string ProfilName { get; set; }
        decimal ProfilLaenge { get; set; }
        decimal ProfilBreite { get; set; }
        string KatalogNummer { get; set; }
        string StammdatenDateiFuerBearbeitung { get; set; }
        string Spannsituation { get; set; }
        string SpannSituationAlternativ { get; set; }
        string StartXRegel { get; set; }
        string FraesBild { get; set; }
        string TextHP { get; set; }
        string TextNP { get; set; }
        decimal LLBreite { get; set; }
        decimal LLBreiteAmBildschirm { get; set; }
        decimal LLHoehe { get; set; }
        decimal DurchmesserBohrung { get; set; }
        decimal LochAbstand { get; set; }
        decimal LochAbstandAmBildschirm { get; set; }
        decimal Winkel { get; set; }
        bool ManuellGeloescht { get; set; }
        bool Passiv { get; set; }
        bool NichtFreigegeben { get; set; }
        bool MassXEditierbar { get; set; }
        bool GroesseEditierbar { get; set; }
    }
}

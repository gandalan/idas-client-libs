using System;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ReportData
{
    public interface IMaterialReportItem
    {
        decimal Stueckzahl { get; set; }
        string SameLengthCount { get; set; }
        int Korrekturmass { get; set; }
        string Einteilung { get; set; }
        string PCode { get; set; }
        string EtikettenNummer { get; set; }
        string VorgangsNummer { get; set; }
        string PositionsNummer { get; set; }
        float ZuschnittLaenge { get; set; }
        string FachNummer { get; set; }
        string ZuschnittWinkel { get; set; }
        string KatalogNummer { get; set; }
        string FarbCode { get; set; }
        string FarbBezeichnung { get; set; }
        string FarbKuerzel { get; set; }
        Guid VorgangGuid { get; set; }
        Guid BelegPositionGuid { get; set; }
        Guid BelegPositionAVGuid { get; set; }
    }

    public class MaterialReportItem : IMaterialReportItem
    {
        public decimal Stueckzahl { get; set; }
        public string SameLengthCount { get; set; } = "";
        public int Korrekturmass { get; set; }
        public string Einteilung { get; set; } = "-";
        public string PCode { get; set; }
        public string EtikettenNummer { get; set; } = "-";
        public string VorgangsNummer { get; set; }
        public string PositionsNummer { get; set; }
        public float ZuschnittLaenge { get; set; }
        public string FachNummer { get; set; } = "$Fnr$";
        public string ZuschnittWinkel { get; set; }
        public string KatalogNummer { get; set; }
        public string FarbCode { get; set; }
        public string FarbBezeichnung { get; set; }
        public string FarbKuerzel { get; set; }
        public Guid VorgangGuid { get; set; }
        public Guid BelegPositionGuid { get; set; }
        public Guid BelegPositionAVGuid { get; set; }
    }
}

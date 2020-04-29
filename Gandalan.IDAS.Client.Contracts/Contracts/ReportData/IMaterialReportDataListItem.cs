namespace Gandalan.IDAS.Client.Contracts.Contracts.ReportData
{
    public interface IMaterialReportDataListItem
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
    }

    public class MaterialReportDataListItem : IMaterialReportDataListItem
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
    }
}

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
}

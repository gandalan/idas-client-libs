namespace Gandalan.IDAS.WebApi.Client.DTOs.Reports.SerienMaterialliste;

public class SerienMateriallisteZubehoerReportDataDTO
{
    public string Serie { get; set; }
    public string Katalognummer { get; set; }
    public string ProduktionsFarbText { get; set; }
    public string Farbkuerzel { get; set; }
    public string FarbZusatzText { get; set; }
    public string FarbBezeichnung { get; set; }
    public string FarbCode { get; set; }
    public int Anzahl { get; set; }
    public decimal Laufmeter { get; set; }
    public string Einheit { get; set; }
    public string Bezeichnung { get; set; }
    public string OberflaecheBezeichnung { get; set; }
    public decimal VE_Menge { get; set; }
    public decimal Artikel_VE_Menge { get; set; }
    public string SerieKuerzel { get; set; }
}
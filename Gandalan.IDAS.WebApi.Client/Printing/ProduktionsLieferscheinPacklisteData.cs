namespace Gandalan.IDAS.WebApi.Client.Printing;

public class ProduktionsLieferscheinPacklisteData
{
    public string Stueckzahl { get; set; }
    public string Katalognummer { get; set; }
    public string Bezeichnung { get; set; }
    public string Farbe { get; set; }
    public string ProduktionsFarbText { get; set; }
    public string Laenge { get; set; }
    public string Winkel { get; set; }
    public string Einheit { get; set; }
    public decimal? VE_Menge { get; set; }
    public bool IstVE { get; set; }
}
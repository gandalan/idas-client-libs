namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;

public class MandantZahlungsinformationDruckDTO
{
    public string Bezeichnung { get; set; }
    public string IBAN { get; set; }
    public string Kontoinhaber { get; set; }
    public string BIC { get; set; }
    public string Bankname { get; set; }
}

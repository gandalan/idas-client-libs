using System.Text;

namespace Gandalan.IDAS.WebApi.DTO;

public class AdresseDruckDTO
{
    public string Anrede { get; set; }
    public string Nachname { get; set; }
    public string Vorname { get; set; }
    public string Firmenname { get; set; }
    public string Zusatz { get; set; }
    public string AdressZusatz1 { get; set; }
    public string Strasse { get; set; }
    public string Hausnummer { get; set; }
    public string Postleitzahl { get; set; }
    public string Ort { get; set; }
    public string Ortsteil { get; set; }
    public string Land { get; set; }
    public bool IstInland { get; set; }

    public AdresseDruckDTO() { }

    public AdresseDruckDTO(BeleganschriftDTO beleganschrift)
    {
        if (beleganschrift == null)
        {
            return;
        }

        Anrede = beleganschrift.Anrede;
        Nachname = beleganschrift.Nachname;
        Vorname = beleganschrift.Vorname;
        Firmenname = beleganschrift.Firmenname;
        Zusatz = beleganschrift.Zusatz;
        AdressZusatz1 = beleganschrift.AdressZusatz1;
        Strasse = beleganschrift.Strasse;
        Hausnummer = beleganschrift.Hausnummer;
        Postleitzahl = beleganschrift.Postleitzahl;
        Ort = beleganschrift.Ort;
        Ortsteil = beleganschrift.Ortsteil;
        Land = beleganschrift.Land;
        IstInland = beleganschrift.IstInland;
    }

    public override string ToString()
    {
        StringBuilder adressText = new();

        adressText.AppendLine(Anrede);
        adressText.AppendLine(BuildAnschriftsName());

        if (!string.IsNullOrEmpty(AdressZusatz1))
        {
            adressText.AppendLine(AdressZusatz1);
        }

        if (!string.IsNullOrEmpty(Ortsteil))
        {
            adressText.AppendLine(Ortsteil);
        }

        adressText.AppendLine($"{Strasse} {Hausnummer}");
        adressText.Append($"{Postleitzahl} {Ort}");

        if (!IstInland)
        {
            adressText.AppendLine().Append(Land?.ToUpper());
        }

        return adressText.ToString();
    }

    private string BuildAnschriftsName()
    {
        var adesszusatz = "";
        var name1 = string.IsNullOrEmpty(Vorname) ? Nachname : Vorname;
        var name2 = string.IsNullOrEmpty(Vorname) ? adesszusatz : Nachname;
        return (!string.IsNullOrEmpty(Firmenname) ? $"{Firmenname}" : ($"{name1} {name2}")).Trim();
    }
}

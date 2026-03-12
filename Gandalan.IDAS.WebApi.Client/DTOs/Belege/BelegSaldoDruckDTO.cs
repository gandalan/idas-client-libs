using Gandalan.IDAS.WebApi.Client.Constants;

namespace Gandalan.IDAS.WebApi.DTO;

public class BelegSaldoDruckDTO
{
    public int Reihenfolge { get; set; }
    public string Text { get; set; }
    public string Betrag { get; set; }
    public string Rabatt { get; set; }
    public bool IsLastElement { get; set; }

    public BelegSaldoDruckDTO() { }

    public BelegSaldoDruckDTO(BelegSaldoDTO saldo, bool isAufAnfrage = false)
    {
        if (saldo == null)
        {
            return;
        }

        Reihenfolge = saldo.Reihenfolge;
        Text = saldo.Text;

        if (isAufAnfrage)
        {
            Betrag = "auf Anfrage";
            Rabatt = string.Empty;
        }
        else
        {
            var vorzeichen = saldo.Typ == "Abschlag" ? '-' : ' ';
            Betrag = vorzeichen + saldo.Betrag.ToString("F2", Global.CultureInfo);
            Rabatt = saldo.Rabatt > 0 ? saldo.Rabatt.ToString("G29", Global.CultureInfo) : "";
        }
    }
}

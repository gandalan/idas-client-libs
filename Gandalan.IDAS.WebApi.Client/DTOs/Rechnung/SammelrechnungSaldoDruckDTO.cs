using System.Collections.Generic;
using System.Linq;

using Gandalan.IDAS.WebApi.Client.Constants;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;

public class SammelrechnungSaldoDruckDTO
{
    public int Reihenfolge { get; set; }
    public string Text { get; set; }
    public string Betrag { get; set; }
    public string Rabatt { get; set; }
    public bool IsLastElement { get; set; }

    public SammelrechnungSaldoDruckDTO(SammelrechnungSaldenDTO saldo, bool isLastElement)
    {
        Reihenfolge = saldo.Reihenfolge;
        Text = saldo.Text;
        Betrag = saldo.Betrag.ToString(culture);
        Rabatt = saldo.Rabatt > 0 ? saldo.Rabatt.ToString("G29", Global.CultureInfo) : "";
        IsLastElement = isLastElement;
    }

    public static List<SammelrechnungSaldoDruckDTO> ListFromDTOs(IList<SammelrechnungSaldenDTO> salden)
    {
        var druckSalden = new List<SammelrechnungSaldoDruckDTO>();

        if (salden != null && salden.Any())
        {
            var maxReihenfolge = salden.Max(p => p.Reihenfolge);

            foreach (var saldo in salden)
            {
                if (saldo.Name == "Warenwert")
                {
                    continue;
                }

                druckSalden.Add(new SammelrechnungSaldoDruckDTO(saldo, isLastElement: saldo.Reihenfolge == maxReihenfolge));
            }
        }

        return druckSalden.OrderBy(s => s.Reihenfolge).ToList();
    }
}

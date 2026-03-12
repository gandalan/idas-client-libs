using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Gandalan.IDAS.WebApi.Client.Constants;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;

public class SammelrechnungPositionDruckDTO
{
    public int LaufendeNummer { get; set; }
    public string RechnungNummer { get; set; }
    public string RechnungDatum { get; set; }
    public string VorgangsDatum { get; set; }
    public string RechnungKommission { get; set; }
    public string RechnungBetrag { get; set; }
    public string Ueberschrift { get; set; }
    public IList<SammelrechnungSaldoDruckDTO> RechnungSalden { get; set; }

    public SammelrechnungPositionDruckDTO(SammelrechnungPositionenDTO position)
    {
        LaufendeNummer = position.LaufendeNummer;
        RechnungNummer = position.RechnungNummer.ToString(CultureInfo.InvariantCulture);
        RechnungDatum = position.RechnungDatum.ToString("d", Global.CultureInfo);
        VorgangsDatum = position.VorgangsDatum.ToString("d", Global.CultureInfo);
        RechnungKommission = position.RechnungKommision;
        var warenwertSalde = position.Salden.FirstOrDefault(s => s.Name == "Warenwert");
        RechnungBetrag = warenwertSalde.Betrag.ToString(Global.CultureInfo);
        RechnungSalden = SammelrechnungSaldoDruckDTO.ListFromDTOs(position.Salden);
    }

    public static List<SammelrechnungPositionDruckDTO> ListFromDTOs(IList<SammelrechnungPositionenDTO> positionen)
    {
        var druckPositionen = new List<SammelrechnungPositionDruckDTO>();

        if (positionen != null && positionen.Any())
        {
            foreach (var position in positionen)
            {
                druckPositionen.Add(new SammelrechnungPositionDruckDTO(position));
            }
        }

        return druckPositionen.OrderBy(p => p.LaufendeNummer).ToList();
    }
}

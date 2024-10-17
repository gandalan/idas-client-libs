using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO;

public class GesamtLieferzusageDTO : ICloneable
{
    public Guid GesamtLieferzusageGuid { get; set; }
    public Guid MandantGuid { get; set; }
    public DateTime Liefertermin { get; set; }
    public string KatalogNummer { get; set; }
    public string BestellNummer { get; set; }
    public string Einheit { get; set; }
    public decimal Stueckzahl { get; set; }
    public decimal UngedeckteStueckzahl { get; set; }
    public decimal Laufmeter { get; set; }
    public decimal UngedeckteLaufmeter { get; set; }
    public string FarbBezeichnung { get; set; }
    public string FarbZusatzText { get; set; }
    public string FarbKuerzel { get; set; }
    public Guid FarbKuerzelGuid { get; set; }
    public string FarbCode { get; set; }
    public string PulverCode { get; set; }
    public string FarbeItem { get; set; }
    public Guid FarbItemGuid { get; set; }
    public string OberFlaeche { get; set; }
    public Guid OberFlaecheGuid { get; set; }
    public bool IstSonderfarbe { get; set; }
    public bool IstVE { get; set; }
    public decimal? VE_Menge { get; set; }
    public List<GesamtLieferzusageBuchungDTO> Buchungen { get; set; }
    public object Clone()
    {
        return new GesamtLieferzusageDTO
        {
            GesamtLieferzusageGuid = GesamtLieferzusageGuid,
            MandantGuid = MandantGuid,
            Liefertermin = Liefertermin,
            KatalogNummer = KatalogNummer,
            BestellNummer = BestellNummer,
            Einheit = Einheit,
            Stueckzahl = Stueckzahl,
            Laufmeter = Laufmeter,
            FarbBezeichnung = FarbBezeichnung,
            FarbZusatzText = FarbZusatzText,
            FarbKuerzel = FarbKuerzel,
            FarbKuerzelGuid = FarbKuerzelGuid,
            FarbCode = FarbCode,
            FarbeItem = FarbeItem,
            FarbItemGuid = FarbItemGuid,
            OberFlaeche = OberFlaeche,
            OberFlaecheGuid = OberFlaecheGuid,
            IstSonderfarbe = IstSonderfarbe,
            PulverCode = PulverCode,
            UngedeckteStueckzahl = UngedeckteStueckzahl,
            UngedeckteLaufmeter = UngedeckteLaufmeter,
            IstVE = IstVE,
            VE_Menge = VE_Menge,
            Buchungen = Buchungen.Select(x => (GesamtLieferzusageBuchungDTO)x.Clone()).ToList()
        };
    }
}

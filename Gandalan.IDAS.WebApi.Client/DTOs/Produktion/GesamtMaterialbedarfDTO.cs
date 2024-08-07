using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO;

public class GesamtMaterialbedarfDTO : ICloneable
{
    public Guid GesamtMaterialbedarfGuid { get; set; }
    public Guid MandantGuid { get; set; }
    public bool IsGruppe => Children != null && Children.Count != 0;
    public List<GesamtMaterialbedarfDTO> Children { get; set; }
    public Guid ProduktionsMaterialbedarfGuid { get; set; }
    public MaterialbedarfDTO ProduktionsMaterialbedarf { get; set; }
    public Guid SerieGuid { get; set; }
    public SerieDTO Serie { get; set; }
    public string SerienName { get; set; }
    public Guid BelegPositionGuid { get; set; }
    public BelegPositionDTO BelegPosition { get; set; }
    public Guid BelegPositionAVGuid { get; set; }
    public BelegPositionAVDTO BelegPositionAV { get; set; }
    public DateTime Liefertermin { get; set; }
    public string KatalogNummer { get; set; }
    public string Vorgangsnummer { get; set; }
    public string ArtikelBezeichnung { get; set; }
    public string Einheit { get; set; }
    public decimal Stueckzahl { get; set; }
    public decimal GedeckteStueckzahl { get; set; }
    public decimal UngedeckteStueckzahl => Stueckzahl - GedeckteStueckzahl;
    public decimal Laufmeter { get; set; }
    public decimal GedeckteLaufmeter { get; set; }
    public decimal UngedeckteLaufmeter => Laufmeter - GedeckteLaufmeter;
    public string FarbBezeichnung { get; set; }
    public string FarbZusatzText { get; set; }
    public string FarbKuerzel { get; set; }
    public Guid FarbKuerzelGuid { get; set; }
    public string FarbCode { get; set; }
    public string FarbeItem { get; set; }
    public Guid FarbItemGuid { get; set; }
    public string OberFlaeche { get; set; }
    public Guid OberFlaecheGuid { get; set; }
    public string PulverCode { get; set; }
    public bool IstZuschnitt { get; set; }
    public float ZuschnittLaenge { get; set; }
    public bool IstStangenoptimiert { get; set; }
    public string ZuschnittWinkel { get; set; }
    public bool IstSonderfarbe { get; set; }
    public KatalogArtikelArt KatalogArtikelArt { get; set; }
    public decimal DeckungInPercent => Einheit != null ? Einheit.StartsWith("S") ? (Stueckzahl != 0 ? GedeckteStueckzahl / Stueckzahl : 0) : (Laufmeter != 0 ? GedeckteLaufmeter / Laufmeter : 0) : 0;
    public bool IstVE { get; set; }
    public decimal? VE_Menge { get; set; }
    public object Clone()
    {
        return new GesamtMaterialbedarfDTO
        {
            GesamtMaterialbedarfGuid = GesamtMaterialbedarfGuid,
            MandantGuid = MandantGuid,
            ArtikelBezeichnung = ArtikelBezeichnung,
            BelegPosition = BelegPosition,
            BelegPositionGuid = BelegPositionGuid,
            BelegPositionAV = BelegPositionAV,
            BelegPositionAVGuid = BelegPositionAVGuid,
            Serie = Serie,
            SerieGuid = SerieGuid,
            SerienName = SerienName,
            Children = Children.Select(x => (GesamtMaterialbedarfDTO)x.Clone()).ToList(),
            ProduktionsMaterialbedarf = ProduktionsMaterialbedarf,
            ProduktionsMaterialbedarfGuid = ProduktionsMaterialbedarfGuid,
            Einheit = Einheit,
            Liefertermin = Liefertermin,
            KatalogNummer = KatalogNummer,
            Vorgangsnummer = Vorgangsnummer,
            Stueckzahl = Stueckzahl,
            Laufmeter = Laufmeter,
            FarbBezeichnung = FarbBezeichnung,
            FarbKuerzel = FarbKuerzel,
            FarbZusatzText = FarbZusatzText,
            FarbKuerzelGuid = FarbKuerzelGuid,
            FarbCode = FarbCode,
            FarbeItem = FarbeItem,
            FarbItemGuid = FarbItemGuid,
            OberFlaeche = OberFlaeche,
            OberFlaecheGuid = OberFlaecheGuid,
            PulverCode = PulverCode,
            IstZuschnitt = IstZuschnitt,
            ZuschnittLaenge = ZuschnittLaenge,
            ZuschnittWinkel = ZuschnittWinkel,
            IstSonderfarbe = IstSonderfarbe,
            KatalogArtikelArt = KatalogArtikelArt,
            GedeckteStueckzahl = GedeckteStueckzahl,
            GedeckteLaufmeter = GedeckteLaufmeter,
            IstVE = IstVE,
            VE_Menge = VE_Menge,
            IstStangenoptimiert = IstStangenoptimiert
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class GesamtMaterialbedarfDTO
    {
        public Guid GesamtMaterialbedarfGuid { get; set; }
        public Guid MandantGuid { get; set; }
        public bool IsGruppe { get { return Children != null && Children.Any(); } }
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
        public decimal Laufmeter { get; set; }
        public string FarbBezeichnung { get; set; }
        public string FarbKuerzel { get; set; }
        public Guid FarbKuerzelGuid { get; set; }
        public string FarbCode { get; set; }
        public string FarbeItem { get; set; }
        public Guid FarbItemGuid { get; set; }
        public string OberFlaeche { get; set; }
        public Guid OberFlaecheGuid { get; set; }
        public bool IstZuschnitt { get; set; }
        public float ZuschnittLaenge { get; set; }
        public string ZuschnittWinkel { get; set; }
        public bool IstSonderfarbe { get; set; }
        public KatalogArtikelArt KatalogArtikelArt { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class GesamtLieferzusageDTO
    {
        public Guid GesamtLieferzusageGuid { get; set; }
        public Guid MandantGuid { get; set; }        
        public DateTime Liefertermin { get; set; }
        public string KatalogNummer { get; set; }
        public string BestellNummer { get; set; }
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
        public bool IstSonderfarbe { get; set; }
    }
}


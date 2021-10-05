using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class KatalogArtikelFarbZuordnungDTO
    {
        public Guid FarbItemGuid { get; set; }

        public decimal Preis { get; set; }
        public bool Freigabe_IBOS { get; set; }
        public bool Freigabe_BestellFix { get; set; }
        public bool Freigabe_ARTOS { get; set; }

        public int MengeGrossVE { get; set; }
        public int MengeGrossVE2 { get; set; }
        public int MeldeSchwelleGrossVEs { get; set; }

        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.UI
{
    public class UIKonfiguratorFeldDTO
    {
        public int EingabeLevel { get; set; }
        public int Reihenfolge { get; set; }
        public string Caption { get; set; }
        public string Tag { get; set; }
        public string Kuerzel { get; set; }
        public string WerteListeName { get; set; }
        public string VorgabeWert { get; set; }
        public string BelegBlattText { get; set; }
        public string AngebotsText { get; set; }
        public int? ProfilId { get; set; }
        public int? GehoertZuProfilId { get; set; }
        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
        public Guid UIKonfiguratorFeldGuid { get; set; }
    }
}

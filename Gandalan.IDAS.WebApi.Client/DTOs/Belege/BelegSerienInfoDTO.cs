using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Belege
{
    /// <summary>
    /// Zusammenfassung der Serien, denen die Positionen des Belegs zugewiesen sind.
    /// </summary>
    public class BelegSerienInfoDTO
    {
        public Guid BelegGuid { get; set; }
        public IList<SerieInfoDTO> SerienInfos { get; set; }
    }

    public class SerieInfoDTO
    {
        public Guid SerieGuid { get; set; }
        public string Name { get; set; }
        public string Kuerzel { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }
        public bool StaendigeSerie { get; set; }
        public decimal Kapazitaet { get; set; }
        public decimal KapazitaetInMin { get; set; }
        public decimal KapazitaetReserviert { get; set; }
    }
}

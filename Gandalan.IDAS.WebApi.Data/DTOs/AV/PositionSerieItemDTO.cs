using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data.DTOs.AV
{
    public class PositionSerieItemDTO
    {
        public Guid BelegPositionGuid { get; set; }
        public string Position { get; set; }
        public int Menge { get; set; }
        public int Vorlauf { get; set; }
        public string SerieAuslastung { get; set; }
        public Guid SerieGuid { get; set; }
        public DateTime ProduktionsDatum { get; set; }
        public DateTime LieferDatum { get; set; }
        public string PositionInfo { get; set; }
        public decimal KapBedarf { get; set; }
        public decimal KapBedarfGes { get; set; }
        public bool HatNachfolgeBelegPosition { get; set; }
    }
}

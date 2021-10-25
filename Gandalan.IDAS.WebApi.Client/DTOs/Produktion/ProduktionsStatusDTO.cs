using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduktionsStatusDTO
    {
        public ProduktionsStatusDTO()
        {
            Erstellt = DateTime.UtcNow;
        }

        public Guid ProduktionsStatusGuid { get; set; }
        public Guid BelegPositionAVGuid { get; set; }
        public DateTime Erstellt { get; set; }
        public string Ersteller { get; set; }

        public Guid SerieGuid { get; set; }
        public string SerieBezeichnung { get; set; }

        public ProduktionsStatiWerteDTO AktuellerStatus { get; set; }

        public List<ProduktionsStatusHistorieDTO> Historie { get; set; } = new List<ProduktionsStatusHistorieDTO>();
        public DateTime ChangedDate { get; set; }
    }
}

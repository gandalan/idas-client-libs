using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduktionsStatusDTO
    {
        public Guid ProduktionsStatusGuid { get; set; }
        public Guid BelegPositionGuid { get; set; }
        public DateTime Erstellt { get; set; }
        public string Ersteller { get; set; }

        public Guid SerieGuid { get; set; }
        public string SerieBezeichnung { get; set; }

        public ProduktionsStatiDTO AktuellerStatus { get; set; }

        public List<ProduktionsStatusHistorieDTO> Historie { get; set; }
    }
}

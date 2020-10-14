using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Reports
{
    public class SerienPacklisteGruppeDataDTO
    {
        public string VorgangsNummer { get; set; }
        public string PositionsNummer { get; set; }
        public string Einbauort { get; set; }
        public string SerienKennzeichen { get; set; }
        public string VorgangsGruppenKennzeichen { get; set; }
        public List<SerienPacklisteGruppeItemDataDTO> Items { get; set; } = new List<SerienPacklisteGruppeItemDataDTO>();
    }
}

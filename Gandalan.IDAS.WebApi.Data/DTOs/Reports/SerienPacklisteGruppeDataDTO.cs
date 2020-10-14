using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Reports
{
    public class SerienPacklisteGruppeDataDTO
    {
        public string LieferscheinNummer { get; set; }
        public string SerienKennzeichen { get; set; }
        public string SerienauftragsNummer { get; set; }
        public List<SerienPacklisteGruppeItemDataDTO> Items { get; set; } = new List<SerienPacklisteGruppeItemDataDTO>();
    }
}

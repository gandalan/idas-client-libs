using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Reports
{
    public class SerienSaegelisteDataDTO
    {
        public string Titel { get; set; }
        public string Serienkennzeichen { get; set; }
        public bool SaegemaßeOhneKorrektur { get; set; } = true;
        public bool EtikettenZugehoerigkeit { get; set; } = false;
        public string Zeitvorgabe { get; set; }
        public List<SerienSaegelisteProfilgruppeDataDTO> Profilgruppen { get; set; } = new List<SerienSaegelisteProfilgruppeDataDTO>();
    }
}

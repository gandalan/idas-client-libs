using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Reports
{
    public class SerienSaegelisteProfilgruppeDataDTO
    {
        public string Titel { get; set; }
        public string Farbe { get; set; }
        public string Oberflaeche { get; set; }
        public string ProfilSchnittBild { get; set; }
        public string Gesamtbedarf { get; set; }

        public List<SerienSaegelistenProfilgruppeSchnittDataDTO> Schnitte { get; set; } = new List<SerienSaegelistenProfilgruppeSchnittDataDTO>();
        public int FarbeAsInt { get; set; }

        public string KatalogNummer { get; set; }

        public string FarbKuerzel { get; set; }

    }
}

using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Reports
{
    public class SerienPacklisteGruppeDataDTO
    {
        public string Kunde { get; set; }
        public string Ort { get; set; }
        public string Kommission { get; set; }
        public string VorgangsNummer { get; set; }
        public string PositionsNummer { get; set; }
        public string Einbauort { get; set; }
        public string SerienKennzeichen { get; set; }
        public string VorgangsGruppenKennzeichen { get; set; }
        public List<SerienPacklisteGruppeItemDataDTO> Items { get; set; } = new List<SerienPacklisteGruppeItemDataDTO>();
    }
}

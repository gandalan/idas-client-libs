using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Settings
{
    public class ProduktionsSettingsDTO
    {
        public List<ProduktionProduktfamilieSettingsDTO> ProduktionProduktfamilieSettingList { get; set; }
        public bool SprossenfreiEnabled { get; set; }
        public bool SaegedatenAufEtiketten { get; set; } = false;
        public bool MaschinenkederVerwenden { get; set; } = false;
        public bool PacklistenEtikettenZusammengefasst { get; set; } = true;
        public string EtikettSerienkennzeichen { get; set; } = "Ohne";
        public string PackEtikettSerienkennzeichen { get; set; } = "Kürzel";
        public bool PrintPCode { get; set; } = true;
        public bool PrintPCodeASQRCode { get; set; } = true;
        public bool Schutzplattenmontage { get; set; } = false;
        public bool WeisserKeder { get; set; } = false;
        public bool SortierungMitPositionsbezug { get; set; } = false;
        public bool HaendlerNameAufEtikett { get; set; } = false;
        public bool HaendlerKommAufEtikett { get; set; } = false;
        public bool VorgangKommAufEtikett { get; set; } = true;
        public bool PositionKommAufEtikett { get; set; } = false;
        public bool EinbauOrtAufEtikett { get; set; } = true;
        public DateTime ChangedDate { get; set; }
    }
}

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
        public bool PrintPCodeASQRCode { get; set; } = true;
        public bool HaendlerKommAufEtikett { get; set; } = false;
        public bool VorgangKommAufEtikett { get; set; } = true;
        public bool PositionKommAufEtikett { get; set; } = false;
        public bool EinbauOrtAufEtikett { get; set; } = true;
        public DateTime ChangedDate { get; set; }
    }
}

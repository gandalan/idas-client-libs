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
        public DateTime ChangedDate { get; set; }
    }
}

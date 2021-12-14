using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Settings
{
    public class ProduktionProduktfamilieSettingsDTO
    {
        public string ProduktfamilienName { get; set; }
        public bool SprossenFrei { get; set; }
        public string Buerste { get; set; }
        public bool FederkraftErhoeht { get; set; }
    }
}

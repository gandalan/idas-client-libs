﻿using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Settings
{
    public class ProduktionProduktfamilieSettingsDTO
    {
        public string ProduktfamilienName { get; set; }
        public bool SprossenFrei { get; set; }
        public bool Vorbiegen { get; set; }
        public List<string> MoeglicheVariantenVorbiegen { get; set; }
        public string Buerste { get; set; }
        public bool FederkraftErhoeht { get; set; }
        public bool VerschlussGegenstueckVor2022 { get; set; }
    }
}

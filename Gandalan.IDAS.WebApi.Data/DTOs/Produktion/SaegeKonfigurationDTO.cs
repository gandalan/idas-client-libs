using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Produktion
{
    /// <summary>
    /// DTO für die Konfiguration von Sägen in IBOS3
    /// </summary>
    public class SaegeKonfigurationDTO
    {
        /// <summary>
        /// Bezeichnung der Säge
        /// </summary>
        public string Bezeichnung { get; set; }

        /// <summary>
        /// Modellbezeichnung des ISaegeDatenGenerator, der genutzt werden soll
        /// </summary>
        public string Modell { get; set; }

        /// <summary>
        /// Bezeichnung des SaegemassKorrekturSatzDTO, das genutzt werden soll
        /// </summary>
        public string KorrekturSatz { get; set; }
    }
}

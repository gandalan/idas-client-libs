using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die Verwaltung der Sägemaßkorrekturen
    /// </summary>
    public class SaegemassKorrekturSatzDTO
    {
        /// <summary>
        /// Bezeichnung des Sägemaßkorrektursatzes
        /// </summary>
        public string Bezeichnung { get; set; } 

        /// <summary>
        /// Liste mit profilbezogenen Sägemaßkorrekturen
        /// </summary>
        public IList<SaegemassKorrekturDTO> SaegemassKorrekturen { get; set; }

    }
}

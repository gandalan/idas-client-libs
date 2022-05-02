using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die Verwaltung der Sägemaßkorrekturen
    /// </summary>
    public class SaegemassKorrekturDTO
    {
        /// <summary>
        /// Katalognummer des Profils, für das die Sägemaßkorrektur gilt
        /// </summary>
        public string KatalogNummer { get; set; }

        /// <summary>
        /// Korrekturmaß bei 90° Schnitt (in mm)
        /// </summary>
        public float Korrektur90Grad { get; set; }

        /// <summary>
        /// Korrekturmaß bei 45° Schnitt (in mm)
        /// </summary>
        public float Korrektur45Grad { get; set; }


        /// <summary>
        /// Winkelkorrektur bei 45° Schnitt (in °)
        /// </summary>
        public float WinkelKorrektur45Grad { get; set; }

        /// <summary>
        /// Winkelkorrektur bei 90° Schnitt (in °)
        /// </summary>
        public float WinkelKorrektur90Grad { get; set; }
    }
}

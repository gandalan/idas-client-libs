using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die Verwaltung der Sägemaßkorrekturen
    /// </summary>
    public class SaegemassKorrekturDTO
    {
        public DateTime ChangedDate { get; set; }

        public string KatalogNummer { get; set; }

        public float Korrektur90Grad { get; set; }

        public float Korrektur45Grad { get; set; }

    }
}

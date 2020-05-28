using Newtonsoft.Json;
using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die IBOS3 Ablageverwaltung
    /// </summary>
    public class AblageFachDTO
    {
        public Guid AblageFachGuid { get; set; }

        [JsonIgnore]
        public bool Belegt
        {
            get
            {
                return MaterialBedarfGuids != null ? MaterialBedarfGuids.Length > 0 : false;
            }
        }

        public int FachNr { get; set; }

        /// <summary>
        /// GUIDs der ProduktGrupptenDTOs, die im Ablagefach abgelegt werden können
        /// </summary>
        public Guid[] ProduktGruppenGuids { get; set; }

        /// <summary>
        /// GUIDs der aktuell im Ablagefach abgelegten MaterialbedarfDTOs
        /// </summary>
        public Guid[] MaterialBedarfGuids { get; set; }

    }
}

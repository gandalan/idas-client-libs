using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die IBOS3 Ablageverwaltung
    /// </summary>
    public class AblageDTO
    {
        public Guid AblageGuid { get; set; }
        public DateTime ChangedDate { get; set; }

        public IList<AblageFachDTO> AblageFaecher { get; set; }

        public string Standort { get; set; }

        public string Bezeichnung { get; set; }

        public string Kuerzel { get; set; }

    }
}

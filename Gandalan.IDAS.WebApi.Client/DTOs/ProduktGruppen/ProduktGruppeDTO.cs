using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduktGruppeDTO
    {
        public Guid ProduktGruppeGuid { get; set; }
        public string KurzBezeichnung { get; set; }
        public string Bezeichnung { get; set; }
        public virtual IList<ProduktFamilieDTO> ProduktSerien { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }

        public ProduktGruppeDTO()
        {
            ProduktSerien = [];
        }
    }
}

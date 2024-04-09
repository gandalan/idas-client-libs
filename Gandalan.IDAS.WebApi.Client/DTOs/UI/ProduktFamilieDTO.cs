using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduktFamilieDTO
    {
        public Guid ProduktFamilieGuid { get; set; }
        public Guid ProduktGruppeGuid { get; set; }
        public Guid WarengruppenGuid { get; set; }

        public string Bezeichnung { get; set; }
        public string PreisErmittlung { get; set; }
        public string StandardFarbe { get; set; }
        public string KurzBezeichnung { get; set; }
        public bool HatRabatt2 { get; set; }
        public bool HatRabatt3 { get; set; }
        public virtual IList<VarianteDTO> Varianten { get; set; } = [];
        public virtual IList<Guid> StandardFarbKuerzelGuids { get; set; } = [];
        public virtual IList<ProduktFamilieErsatzFarbZuordnungDTO> ErsatzFarbZuordnungen { get; set; } = [];
        public DateTime ChangedDate { get; set; }
        public long Version { get; set; }
    }
}

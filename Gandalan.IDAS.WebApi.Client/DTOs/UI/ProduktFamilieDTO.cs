using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public virtual IList<VarianteDTO> Varianten { get; set; } = new ObservableCollection<VarianteDTO>();
        public virtual IList<Guid> StandardFarbKuerzelGuids { get; set; } = new ObservableCollection<Guid>();
        public virtual IList<ProduktFamilieErsatzFarbZuordnungDTO> ErsatzFarbZuordnungen { get; set; } = new ObservableCollection<ProduktFamilieErsatzFarbZuordnungDTO>();
        public DateTime ChangedDate { get; set; }
        public long Version { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class VarianteDTO
    {
        public Guid VarianteGuid { get; set; }
        public Guid UIDefinitionGuid { get; set; }
        public Guid ProduktFamilieGuid { get; set; }
        public Guid WarengruppeGuid { get; set; }
        public Guid KomponenteGuid { get; set; }

        public string Kuerzel { get; set; }
        public string Name { get; set; }
        public string ElementArt { get; set; }
        public string ElementTyp { get; set; }
        public string Beschreibung { get; set; }
        public string PreisErmittlung { get; set; }
        public string Preisliste { get; set; }
        public string PreisVorschrift { get; set; }
        public string GrenzVorschrift { get; set; }
        public decimal PreislistenFaktor { get; set; }
        public bool MasterKatalog { get; set; }
        public bool HauptKatalog { get; set; }
        public bool ExtraKatalog { get; set; }
        public bool ErfassungIBOS2Moeglich { get; set; }
        public bool ErfassungIBOS1Moeglich { get; set; }
        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        public DateTime ChangedDate { get; set; }
        public long Version { get; set; }

        public UIDefinitionDTO UIDefinition { get; set; }
        public Guid KonfigSatzGuid { get; set; } // Achtung, KonfigSatz-Klasse wird NICHT direkt gemappt!
        public IList<KonfigSatzEintragDTO> KonfigSatz { get; set; }
        public bool IstTechnischeVariante { get; set; }

        public VarianteDTO()
        {
            KonfigSatz = new ObservableCollection<KonfigSatzEintragDTO>();
        }
    }
}
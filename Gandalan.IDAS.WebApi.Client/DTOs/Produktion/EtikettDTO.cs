using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class EtikettDTO
    {
        public Guid EtikettGuid { get; set; }
        public string Kuerzel { get; set; }
        public string Text { get; set; }
        public Guid ZielKennzeichen { get; set; }
        public bool IstSonderEtikett { get; set; }
        public string Typ { get; set; } = "Produktionsetikett";
        public IList<EtikettDatenDTO> EtikettDaten { get; set; } = [];
        public bool EtikettenProfilVorbiegen { get; set; }
        public string EtikettenSonderKuerzel { get; set; }
    }
}

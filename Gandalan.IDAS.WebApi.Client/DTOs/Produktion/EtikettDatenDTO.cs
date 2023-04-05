using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class EtikettDatenDTO
    {
        public Guid EtikettDatenGuid { get; set; }
        public string Position { get; set; }
        public string Typ { get; set; }
        public string Inhalt { get; set; }
    }
}

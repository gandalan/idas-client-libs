using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

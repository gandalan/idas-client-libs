using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class EtikettDTO
    {
        public string Kuerzel { get; set; }
        public string Text { get; set; }
        public Guid ZielKennzeichen { get; set; }
        public bool IstSonderEtikett { get; set; }
    }
}

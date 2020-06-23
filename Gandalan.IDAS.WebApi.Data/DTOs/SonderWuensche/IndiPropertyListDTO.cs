using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche
{
    public class IndiPropertyListDTO
    {
        public string PropertyListTitle { get; set; }
        public string PropertyListTag { get; set; }
        public List<IndiPropertyDTO> Properties { get; set; } = new List<IndiPropertyDTO>();
    }
}

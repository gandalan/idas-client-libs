using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTO
{
    public class IndiPropertyDTO
    {
        public string PropertyTitle { get; set; }
        public List<IndiPropertyItemDTO> IndiProperties { get; set; } = new List<IndiPropertyItemDTO>();
    }
}

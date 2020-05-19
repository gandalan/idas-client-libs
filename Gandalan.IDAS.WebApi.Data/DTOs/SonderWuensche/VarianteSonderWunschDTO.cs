using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche
{
    public class VarianteSonderWunschDTO
    {        
        [JsonProperty]
        public string Name { get; set; }
        public string KederZeigtNach { get; set; }
        public SonderWunschEigenschaftDTO[] Eigenschaften { get; set; }
    }
}

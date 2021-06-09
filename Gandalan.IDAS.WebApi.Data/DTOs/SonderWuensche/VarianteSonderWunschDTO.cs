using Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTO
{
    public class VarianteSonderWunschDTO
    {
        [JsonProperty("Variante")]
        public string Name { get; set; }
        public string KederZeigtNach { get; set; }
        public string[] Imports { get; set; }
        public BelegPositionSonderwunschDTO[] Eigenschaften { get; set; }
    }
}

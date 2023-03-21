using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Data.DTO
{
    public class VarianteSonderWunschDTO
    {
        [JsonProperty("Variante")]
        public string Name { get; set; }
        public string ErfassungsAnsicht { get; set; } = "innen";
        public string ProduktionsAnsicht { get; set; } = "innen";
        public string[] Imports { get; set; }
        public List<BelegPositionSonderwunschDTO> Eigenschaften { get; set; } = new List<BelegPositionSonderwunschDTO>();
    }
}

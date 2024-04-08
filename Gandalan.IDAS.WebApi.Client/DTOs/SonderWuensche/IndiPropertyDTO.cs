using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Data.DTO
{
    public class IndiPropertyDTO
    {
        public string PropertyTitle { get; set; }
        public List<IndiPropertyItemDTO> IndiProperties { get; set; } = new();
    }
}

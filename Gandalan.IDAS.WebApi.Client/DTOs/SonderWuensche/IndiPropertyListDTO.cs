using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Data.DTO
{
    public class IndiPropertyListDTO
    {
        public string PropertyListTitle { get; set; }
        public string PropertyListTag { get; set; }
        public List<IndiPropertyDTO> Properties { get; set; } = new List<IndiPropertyDTO>();
    }
}

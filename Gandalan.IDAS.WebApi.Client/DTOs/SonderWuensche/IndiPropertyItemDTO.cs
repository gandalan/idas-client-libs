using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Data.DTO
{
    public class IndiPropertyItemDTO
    {
        public string PropertyItemTitle { get; set; }
        public string PropertyText { get; set; }
        public string PropertyTag { get; set; }
        public bool IsChecked { get; set; }
        public string Operation { get; set; }
        public List<string> OperationValue { get; set; } = new List<string>();
    }
}

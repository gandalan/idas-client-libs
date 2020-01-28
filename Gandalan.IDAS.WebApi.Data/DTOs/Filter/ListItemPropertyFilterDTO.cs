namespace Gandalan.IDAS.WebApi.Data.DTOs.Filter
{
    public class ListItemPropertyFilterDTO
    {
        public string PropertyName { get; set; }
        public bool IsChecked { get; set; }
        public string PropertyType { get; set; }
        public string Filter { get; set; }               
        public string Operator { get; set; }
        public bool IsActive { get; set; }
    }
}

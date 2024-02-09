using System;

namespace Gandalan.IDAS.WebApi.DTO.DTOs.Filter
{
    public class FilterItemDTO
    {
        public Guid FilterGuid { get; set; }
        public Guid MandantGuid { get; set; }
        public Guid BenutzerGuid { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public string SerializedFilterSetting { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
        public bool IsDeleted { get; set; }
        public long Reihenfolge { get; set; }
    }
}

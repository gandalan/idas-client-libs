using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ContractDTO
    {
        public Guid ContractGuid { get; set; }
        public Guid Owner { get; set; }
        public Guid Partner { get; set; }
        public string Context { get; set; }
        public string Value { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
        public string OwnerName { get; set; }
        public string PartnerName { get; set; }
        public bool IsEditable { get; set; }
        public bool Inherit { get; set; }
    }
}

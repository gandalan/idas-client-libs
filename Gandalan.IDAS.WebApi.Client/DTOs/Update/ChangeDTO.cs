using System;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Update
{
    public class ChangeDTO
    {
        public Guid ChangedGuid { get; set; }
        public DateTime ChangedWhen { get; set; }
        public string ChangeType { get; set; }
        public string ChangeOperation { get; set; }
        public long? MandantId { get; set; }
        public Guid? MandantGuid { get; set; }
        public string Data { get; set; }
    }
}

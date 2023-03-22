using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class FileInfoDTO
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public DateTime? GueltigBis { get; set; }
    }
}

using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class VorgangNachrichtAnhangDTO
    {
        public Guid VorgangNachrichtAnhangGuid { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string URL { get; set; }
    }
}
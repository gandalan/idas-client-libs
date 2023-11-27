using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Allgemein
{
    public class ZusatztextDTO
    {
        public Guid ObjectGuid { get; set; }
        public int LfdNr { get; set; }
        public string Context { get; set; }
        public string Content { get; set; }

    }
}

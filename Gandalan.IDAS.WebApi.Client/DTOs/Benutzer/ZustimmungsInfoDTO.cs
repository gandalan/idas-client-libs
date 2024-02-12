using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ZustimmungsInfoDTO
    {
            public string Dokument { get; set; }
            public string Version { get; set; }
            public DateTime Zeitstempel { get; set; }
            public string Plattform { get; set; }
    }
}

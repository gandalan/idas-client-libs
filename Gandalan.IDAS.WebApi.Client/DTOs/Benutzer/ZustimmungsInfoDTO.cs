using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ChangeInfoDTO
    {
        public DateTime Kontakte { get; set; }
        public DateTime Vorgaenge { get; set; }
        public DateTime Serien { get; set; }
        public DateTime BelegPositionenAV { get; set; }
    }
}

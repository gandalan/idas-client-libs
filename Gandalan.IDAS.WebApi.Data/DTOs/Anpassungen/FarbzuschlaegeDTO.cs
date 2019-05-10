using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class FarbzuschlaegeDTO
    {
        public Dictionary<Guid, AufschlagDTO> Aufpreise { get; set; }
    }

    public struct AufschlagDTO
    {
        public decimal Prozentual { get; set; }
        public decimal AbsolutPosition { get; set; }
        public decimal AbsolutBeleg { get; set; }
    }
}

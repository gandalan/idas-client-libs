using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public partial class KonturDTO
    {
        public Guid KonturGuid { get; set; }
        public virtual ICollection<KonturElementDTO> KonturElemente { get; set; }
        public string Name { get; set; }
        public int Schluessel_1 { get; set; }
        public int Schluessel_2 { get; set; }
        public int Schluessel_3 { get; set; }
        public string Schluessel_4 { get; set; }
        public string Schluessel_5 { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}

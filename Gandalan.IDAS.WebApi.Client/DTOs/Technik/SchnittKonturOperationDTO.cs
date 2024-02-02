using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public partial class SchnittKonturOperationDTO
    {
        public Guid SchnittKonturOperationGuid { get; set; }

        public string Operation { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public int P4 { get; set; }
        public int P5 { get; set; }
        public int Reihenfolge { get; set; }

        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}

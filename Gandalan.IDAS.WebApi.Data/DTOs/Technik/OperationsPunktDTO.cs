using System;

namespace Gandalan.IDAS.WebApi.DTO
{
	public partial class OperationsPunktDTO
	{
        public Guid OperationsPunktGuid { get; set; }

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string Kommentar { get; set; }

		public long Version { get; set; }
        public DateTime ChangedDate { get; set; }        
    }
}
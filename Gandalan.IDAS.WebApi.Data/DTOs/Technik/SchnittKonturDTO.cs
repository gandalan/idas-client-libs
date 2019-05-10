using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public partial class SchnittKonturDTO 
	{
        public Guid SchnittKonturGuid { get; set; }

        public int Reihenfolge { get; set; }
        public bool Verschmelzen { get; set; }
        public int Vorzeichen { get; set; }

        public virtual Guid KonturGuid { get; set; }
		public virtual ICollection<SchnittKonturOperationDTO> Operationen { get; set; }
        
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }        
    }
}
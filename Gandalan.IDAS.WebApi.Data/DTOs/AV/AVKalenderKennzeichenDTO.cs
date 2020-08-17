using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class AVKalenderKennzeichenDTO
    {
        public Guid AVKalenderKennzeichenGuid { get; set; }
        
        public DateTime Datum { get; set; }
        public string TagesKennzeichen { get; set; }
        public string WochenKennzeichen { get; set; }

        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}

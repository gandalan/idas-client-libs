using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Update
{
    public class ChangeDTO
    {
        public Guid ChangedGuid { get; set; }
        public System.DateTime ChangedWhen { get; set; }
        public string ChangeType { get; set; }
        public string ChangeOperation { get; set; }
    }
}

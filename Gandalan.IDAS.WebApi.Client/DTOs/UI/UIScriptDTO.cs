using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class UIScriptDTO
    {
        public Guid ScriptDefinitionGuid { get; set; }
        public string Context { get; set; }
        public string Code { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
    }
}

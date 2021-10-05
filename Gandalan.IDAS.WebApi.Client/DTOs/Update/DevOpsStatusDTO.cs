using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Update
{
    public class DevOpsStatusDTO
    {
        public string Env { get; set; }
        public string DbInfo { get; set; }
        public string CurrentMigration { get; set; }
        public List<string> PendingMigrations { get; set; }
    }
}

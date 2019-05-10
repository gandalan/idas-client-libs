using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Settings
{
    public class SavedAuthToken
    {
        public Guid AuthTokenGuid { get; set; }
        public string UserName { get; set; }
    }
}

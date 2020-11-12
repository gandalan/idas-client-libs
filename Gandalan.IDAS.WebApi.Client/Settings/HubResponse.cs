using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Settings
{
    internal class HubResponse
    {
        public string CMS { get; set; }
        public string DocUrl { get; set; }
        public string IDAS { get; set; }
        public string Prod_I1 { get; set; }
        public string Prod_I2 { get; set; }
        public string Print_Latex { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class AppActivationStatusDTO
    {
        public Guid KundeGuid { get; set; }
        public Guid KundenMandantGuid { get; set; }
        public bool KundenMandantIstAktiv { get; set; }
    }
}

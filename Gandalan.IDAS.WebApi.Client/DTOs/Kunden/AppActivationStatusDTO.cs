using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class AppActivationStatusDTO
    {
        public Guid KundeGuid { get; set; }
        public Guid KundenMandantGuid { get; set; }
        public bool KundenMandantIstAktiv { get; set; }
    }
}

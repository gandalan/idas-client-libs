using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BelegStatusWebRoutinen : WebRoutinenBase
    {
        public BelegStatusWebRoutinen(IWebApiConfig settings) : base(settings) { }
        public BelegStatusDTO Get(Guid belegGuid)
        {
            if(Login())
                return Get<BelegStatusDTO>($"BelegStatus?id={belegGuid}");
            return null;
        }
        public async Task<BelegStatusDTO> GetAsync(Guid belegGuid) => await Task.Run(() => Get(belegGuid));
        public string SaveBelegStatus(BelegStatusDTO belegStatus)
        {
            if (Login())
                return Put($"BelegStatus", belegStatus);
            return null;
        }
        public async Task<string> SaveBelegStatusAsync(BelegStatusDTO belegStatus) => await Task.Run(() => SaveBelegStatus(belegStatus));
    }
}

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

        public BelegStatusDTO GetBelegStatus(Guid belegGuid)
        {
            if(Login())
                return Get<BelegStatusDTO>($"BelegStatus?id={belegGuid}");
            return null;
        }
        public async Task<BelegStatusDTO> GetBelegStatusAsync(Guid belegGuid) => await Task.Run(() => GetBelegStatus(belegGuid));

        public string SaveBelegStatus(Guid belegGuid, string statusCode, string statusText)
        {
            if (Login())
            {
                BelegStatusDTO set = new BelegStatusDTO()
                {
                    BelegGuid = belegGuid,
                    NeuerStatus = statusCode,
                    NeuerStatusText = statusText
                };
                return Put($"BelegStatus", set);
            }
            return null;
        }

        public async Task<string> SaveBelegStatusAsync(Guid belegGuid, string statusCode, string statusText) => await Task.Run(() => SaveBelegStatus(belegGuid, statusCode, statusText));
    }
}

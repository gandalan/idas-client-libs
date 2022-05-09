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

        public BelegStatusDTO GetStatus(Guid belegGuid)
        {
            if(Login())
                return Get<BelegStatusDTO>($"BelegStatus?id={belegGuid}");
            return null;
        }
        public async Task<BelegStatusDTO> GetStatusAsync(Guid belegGuid) => await Task.Run(() => GetStatus(belegGuid));

        public BelegStatusDTO SetStatus(Guid belegGuid, string statusCode, string statusText)
        {
            if (Login())
            {
                BelegStatusDTO set = new BelegStatusDTO()
                {
                    BelegGuid = belegGuid,
                    NeuerStatus = statusCode,
                    NeuerStatusText = statusText
                };
                return Put<BelegStatusDTO>($"BelegStatus", set);
            }
            return null;
        }

        public async Task<BelegStatusDTO> SetStatusAsync(Guid belegGuid, string statusCode, string statusText) => await Task.Run(() => SetStatus(belegGuid, statusCode, statusText));
    }
}

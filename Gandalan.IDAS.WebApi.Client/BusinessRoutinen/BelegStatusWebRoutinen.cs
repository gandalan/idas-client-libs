using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegStatusWebRoutinen : WebRoutinenBase
{
    public BelegStatusWebRoutinen(IWebApiConfig settings) : base(settings) { }

    public async Task<BelegStatusDTO> GetStatusAsync(Guid belegGuid)
        => await GetAsync<BelegStatusDTO>($"BelegStatus?id={belegGuid}");

    public async Task<BelegStatusDTO> SetStatusAsync(Guid belegGuid, string statusCode, string statusText = "")
    {
            var set = new BelegStatusDTO
            {
                BelegGuid = belegGuid,
                NeuerStatus = statusCode,
                NeuerStatusText = statusText
            };
            return await PutAsync<BelegStatusDTO>("BelegStatus", set);
        }
}
using System;
using System.Net;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ProduktionsStatusWebRoutinen : WebRoutinenBase
{
    public ProduktionsStatusWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<ProduktionsStatusDTO[]> GetAllAsync()
    {
        try
        {
            return await GetAsync<ProduktionsStatusDTO[]>("ProduktionsStatus");
        }
        catch (WebException wex)
        {
            if (wex.Response is HttpWebResponse response)
            {
                var code = response.StatusCode;
                if (code == HttpStatusCode.NotFound)
                {
                    return null;
                }
            }

            throw;
        }
    }

    public async Task<ProduktionsStatusDTO> GetProduktionsStatusAsync(Guid guid)
    {
        try
        {
            return await GetAsync<ProduktionsStatusDTO>($"ProduktionsStatus/{guid}");
        }
        catch (WebException wex)
        {
            if (wex.Response is HttpWebResponse response)
            {
                var code = response.StatusCode;
                if (code == HttpStatusCode.NotFound)
                {
                    return null;
                }
            }

            throw;
        }
    }

    public async Task SaveProduktionsStatusAsync(ProduktionsStatusDTO status)
        => await PutAsync("ProduktionsStatus", status);

    public async Task SaveProduktionsStatusHistorieAsync(Guid avGuid, ProduktionsStatusHistorieDTO historie)
        => await PutAsync($"ProduktionsStatus/AddHistorie/{avGuid}", historie);
}

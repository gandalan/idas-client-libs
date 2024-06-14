using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class SonderfarbWebRoutinen : WebRoutinenBase
{
    public SonderfarbWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<BelegDTO> BerechneSonderfarbenAsync(Guid belegGuid)
        => await PostAsync<BelegDTO>($"BelegSonderfarben?bguid={belegGuid}", null);
}
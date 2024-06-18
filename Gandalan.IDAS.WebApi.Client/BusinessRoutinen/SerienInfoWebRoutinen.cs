using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Belege;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class SerienInfoWebRoutinen : WebRoutinenBase
{
    public SerienInfoWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<List<BelegSerienInfoDTO>> GetBelegSerienInfosAsync(IList<Guid> belegGuids)
        => await PostAsync<List<BelegSerienInfoDTO>>("BelegSerienInfo", belegGuids);

    public async Task<List<BelegSerienInfoDTO>> GetVorgangSerienInfosAsync(IList<Guid> vorgangGuids)
        => await PostAsync<List<BelegSerienInfoDTO>>("BelegSerienInfo/GetByVorgangGuids", vorgangGuids);
}
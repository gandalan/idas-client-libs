using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class VorgangStatusTableWebRoutinen : WebRoutinenBase
{
    public VorgangStatusTableWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task UpdateVorgangStatusTableForFunctionAsync(VorgangStatusTableDTO dto)
        => await PostAsync("VorgangStatus/UpdateVorgangStatusTableForFunction", dto, skipAuth: true);

    public async Task<IList<VorgangStatusTableDTO>> GetNotCalculatedVorgangStatusTableForFunctionAsync()
        => await GetAsync<IList<VorgangStatusTableDTO>>("VorgangStatus/GetNotCalculatedVorgangStatusTableForFunction", skipAuth: true);
}

using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class RollenWebRoutinen : WebRoutinenBase
{
    public RollenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<RolleDTO[]> GetAllAsync()
        => await GetAsync<RolleDTO[]>("Rollen");

}
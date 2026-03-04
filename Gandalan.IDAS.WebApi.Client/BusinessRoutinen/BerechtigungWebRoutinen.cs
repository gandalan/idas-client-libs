using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BerechtigungWebRoutinen : WebRoutinenBase
{
    public BerechtigungWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<BerechtigungDTO[]> GetAllAsync()
        => await GetAsync<BerechtigungDTO[]>("Berechtigung");

}

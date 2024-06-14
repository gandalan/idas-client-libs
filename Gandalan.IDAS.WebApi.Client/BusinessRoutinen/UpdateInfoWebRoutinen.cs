using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class UpdateInfoWebRoutinen : WebRoutinenBase
{
    public UpdateInfoWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<UpdateInfoDTO> GetUpdateInfoAsync()
        => await GetAsync<UpdateInfoDTO>("UpdateInfo");
}
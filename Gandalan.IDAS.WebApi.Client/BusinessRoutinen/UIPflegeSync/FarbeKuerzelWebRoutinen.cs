using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class FarbeKuerzelWebRoutinen : WebRoutinenBase
{
    public FarbeKuerzelWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<FarbKuerzelDTO> GetAsync()
        => await GetAsync<FarbKuerzelDTO>("FarbKuerzel/Get");

    public async Task SaveFarbKuerzelAsync(FarbKuerzelDTO dto)
        => await PutAsync("FarbKuerzel/Create", dto);
}

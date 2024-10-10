using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class FarbeGruppenWebRoutinen : WebRoutinenBase
{
    public FarbeGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<FarbGruppeDTO> GetAsync()
        => await GetAsync<FarbGruppeDTO>("FarbGruppe/Get");

    public async Task SaveFarbGruppeAsync(FarbGruppeDTO dto)
        => await PutAsync("FarbGruppe/Create", dto);
}

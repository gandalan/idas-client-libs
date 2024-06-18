using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class FarbGruppenWebRoutinen : WebRoutinenBase
{
    public FarbGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<FarbGruppeDTO[]> GetAllAsync()
        => await GetAsync<FarbGruppeDTO[]>("FarbGruppen");

    public async Task SaveFarbItemGruppeAsync(FarbGruppeDTO dto)
        => await PutAsync("FarbGruppen/" + dto.FarbItemGroupGuid, dto);
}
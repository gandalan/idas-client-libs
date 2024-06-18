using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class FarbenWebRoutinen : WebRoutinenBase
{
    public FarbenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<FarbeDTO[]> GetAllAsync()
        => await GetAsync<FarbeDTO[]>("Farben");

    public async Task SaveFarbItemAsync(FarbeDTO dto)
        => await PutAsync("Farben/" + dto.FarbItemGuid, dto);
}
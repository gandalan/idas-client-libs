using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class FarbenWebRoutinen : WebRoutinenBase
{
    public FarbenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<FarbeDTO> GetAsync()
        => await GetAsync<FarbeDTO>("Farbe/Get");

    public async Task SaveFarbItemAsync(FarbeDTO dto)
        => await PutAsync("Farbe/Create", dto);
}

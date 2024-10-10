using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class ProduktFamilienWebRoutinen : WebRoutinenBase
{
    public ProduktFamilienWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<ProduktFamilieDTO> GetAsync()
        => await GetAsync<ProduktFamilieDTO>("ProduktFamilie/Get");

    public async Task SaveProduktFamilieAsync(ProduktFamilieDTO dto)
        => await PutAsync("ProduktFamilie/Create", dto);
}

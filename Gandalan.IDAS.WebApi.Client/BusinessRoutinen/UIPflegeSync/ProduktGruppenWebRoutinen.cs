using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class ProduktGruppenWebRoutinen : WebRoutinenBase
{
    public ProduktGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<ProduktGruppeDTO> GetAsync()
        => await GetAsync<ProduktGruppeDTO>("ProduktGruppe/Get");

    public async Task SaveProduktFamilieAsync(ProduktGruppeDTO dto)
        => await PutAsync("ProduktGruppe/Create", dto);
}

using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class WarenGruppenWebRoutinen : WebRoutinenBase
{
    public WarenGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<WarenGruppeDTO> GetAsync()
        => await GetAsync<WarenGruppeDTO>("WarenGruppe/Get");

    public async Task SaveProduktFamilieAsync(WarenGruppeDTO dto)
        => await PutAsync("WarenGruppe/Create", dto);
}

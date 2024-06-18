using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class WarenGruppeWebRoutinen : WebRoutinenBase
{
    public WarenGruppeWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<WarenGruppeDTO[]> GetAllAsync()
        => await GetAsync<WarenGruppeDTO[]>("WarenGruppe");

    public async Task SaveWarenGruppeAsync(WarenGruppeDTO dto)
        => await PutAsync($"WarenGruppe/{dto.WarenGruppeGuid}", dto);
}
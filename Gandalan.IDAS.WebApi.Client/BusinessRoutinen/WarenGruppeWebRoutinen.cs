using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class WarenGruppeWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<WarenGruppeDTO[]> GetAllAsync()
        => await GetAsync<WarenGruppeDTO[]>("WarenGruppe");

    public async Task<WarenGruppeDTO> GetByGuidAsync(Guid warenGruppeGuid, bool includeArtikel = true)
        => await GetAsync<WarenGruppeDTO>($"WarenGruppe/{warenGruppeGuid}?includeArtikel={includeArtikel}");

    public async Task SaveWarenGruppeAsync(WarenGruppeDTO dto)
        => await PutAsync($"WarenGruppe/{dto.WarenGruppeGuid}", dto);
}

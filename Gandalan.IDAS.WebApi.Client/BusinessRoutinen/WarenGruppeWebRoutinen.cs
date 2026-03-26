using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class WarenGruppeWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<WarenGruppeDTO[]> GetAllAsync()
        => await GetAsync<WarenGruppeDTO[]>("WarenGruppe");

    public async Task<WarenGruppeListDTO[]> GetListAsync(DateTime? changedSince = null)
        => await GetAsync<WarenGruppeListDTO[]>($"WarenGruppe/list{(changedSince.HasValue ? $"?changedSince={changedSince:O}" : string.Empty)}");

    public async Task<WarenGruppeDTO> GetByGuidAsync(Guid warenGruppeGuid, bool includeArtikel = true)
        => await GetAsync<WarenGruppeDTO>($"WarenGruppe/{warenGruppeGuid}?includeArtikel={includeArtikel}");

    public async Task<KatalogArtikelDTO[]> GetArtikelAsync(Guid warenGruppeGuid)
        => await GetAsync<KatalogArtikelDTO[]>($"WarenGruppe/{warenGruppeGuid}/artikel");

    public async Task SaveWarenGruppeAsync(WarenGruppeDTO dto)
        => await PutAsync($"WarenGruppe/{dto.WarenGruppeGuid}", dto);
}

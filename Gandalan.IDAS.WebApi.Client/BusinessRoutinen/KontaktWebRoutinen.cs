using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class KontaktWebRoutinen : WebRoutinenBase
{
    public KontaktWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<KontaktListItemDTO[]> GetKontakteAsync(bool ohneEndkunden = false)
        => await GetAsync<KontaktListItemDTO[]>($"Kontakt?ohneEndkunden={ohneEndkunden}");

    public async Task<KontaktListItemDTO[]> GetKontakteAsync(DateTime? changedSince, bool ohneEndkunden = false)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<KontaktListItemDTO[]>($"Kontakt?changedSince={changedSince.Value:o}&ohneEndkunden={ohneEndkunden}");
        }

        return await GetAsync<KontaktListItemDTO[]>($"Kontakt?ohneEndkunden={ohneEndkunden}");
    }

    public async Task<KontaktDTO> GetKontaktAsync(Guid kontaktGuid)
        => await GetAsync<KontaktDTO>($"Kontakt/{kontaktGuid}");

    public async Task<KontaktDTO> GetKontaktByKundenNummerAsync(string kundenNummer)
        => await GetAsync<KontaktDTO>($"Kontakt/GetByKundenNummer?kundennummer={kundenNummer}");

    public async Task<KontaktDTO> SaveKontaktAsync(KontaktDTO kontakt)
        => await PutAsync<KontaktDTO>("Kontakt", kontakt);

    public async Task ArchiveKontakteAsync(List<Guid> kontakteIds)
        => await PutAsync("kontakt/archivieren", kontakteIds);

    public async Task UnarchiveKontakteAsync(List<Guid> kontakteIds)
        => await PutAsync("kontakt/entarchivieren", kontakteIds);

    public async Task SetFremdfertigungGuidAsync(IDictionary<Guid, Guid> guidMapping)
        => await PutAsync($"Kontakt/SetFremdfertigungGuid", guidMapping);

    public async Task<KontaktDTO> GetKontaktForFunctionAsync(Guid kontaktGuid, long mandantId)
        => await GetAsync<KontaktDTO>($"GetKontaktForFunction?id={kontaktGuid}&mandantId={mandantId}");

    public async Task<Dictionary<long, List<Guid>>> GetAllKontakteForFunctionAsync(DateTime? changedSince = null)
        => await GetAsync<Dictionary<long, List<Guid>>>($"GetAllKontakteForFunction?changedSince={changedSince:o}");
}

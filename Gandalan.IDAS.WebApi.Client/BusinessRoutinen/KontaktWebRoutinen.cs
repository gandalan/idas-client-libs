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

    public async Task<KontaktListItemDTO[]> GetKontakteAsync()
        => await GetAsync<KontaktListItemDTO[]>("Kontakt");

    public async Task<KontaktListItemDTO[]> GetKontakteAsync(DateTime? changedSince)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<KontaktListItemDTO[]>($"Kontakt?changedSince={changedSince.Value:o}");
        }

        return await GetAsync<KontaktListItemDTO[]>("Kontakt");
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
}
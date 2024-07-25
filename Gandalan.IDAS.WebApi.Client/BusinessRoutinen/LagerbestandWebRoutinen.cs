using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class LagerbestandWebRoutinen : WebRoutinenBase
{
    public LagerbestandWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<LagerbestandDTO> GetAsync(Guid guid)
        => await GetAsync<LagerbestandDTO>($"Lagerbestand/?id={guid}");

    public async Task<List<LagerbestandDTO>> GetAllAsync(DateTime? changedSince)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<List<LagerbestandDTO>>($"Lagerbestand?changedSince={changedSince.Value:o}");
        }

        return await GetAsync<List<LagerbestandDTO>>("Lagerbestand");
    }

    public async Task<List<LagerbestandDTO>> GetUnterschreitungEisernerBestandAsync() => await GetAsync<List<LagerbestandDTO>>("Lagerbestand/UnterschreitungEisernerBestand");

    public async Task<LagerbestandDTO> LagerbuchungAsync(LagerbuchungDTO buchung)
        => await PutAsync<LagerbestandDTO>("Lagerbuchung", buchung);

    public async Task SaveAsync(LagerbestandDTO dto)
        => await PutAsync("Lagerbestand/", dto);

    public async Task DeleteAsync(Guid guid)
        => await DeleteAsync($"Lagerbestand/?id={guid}");

    public async Task<List<LagerbuchungDTO>> GetLagerhistorieAsync(DateTime vonDatum, DateTime bisDatum)
        => await GetAsync<List<LagerbuchungDTO>>($"Lagerbuchung/?vonDatum={vonDatum:o}&bisDatum={bisDatum:o}");
}

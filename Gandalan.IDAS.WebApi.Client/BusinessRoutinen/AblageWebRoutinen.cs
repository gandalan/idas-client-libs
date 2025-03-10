using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AblageWebRoutinen : WebRoutinenBase
{
    public AblageWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<AblageDTO> GetAsync(Guid guid)
    {
        return await GetAsync<AblageDTO>($"Ablage/?id={guid}");
    }

    public async Task<List<AblageDTO>> GetAllAsync(DateTime? changedSince, bool includeDetails = true)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<List<AblageDTO>>($"Ablage?changedSince={changedSince.Value:o}&includeDetails={includeDetails}");
        }

        return await GetAsync<List<AblageDTO>>($"Ablage?includeDetails={includeDetails}");
    }

    public async Task SaveAsync(AblageDTO dto)
    {
        await PutAsync("Ablage/", dto);
    }

    public async Task DeleteAsync(Guid guid)
    {
        await DeleteAsync($"Ablage/?id={guid}");
    }

    public async Task<FachzuordnungResultDTO> SerienFachverteilungAsync(Guid serieGuid)
    {
        return await PutAsync<FachzuordnungResultDTO>($"Ablage/SerienFachverteilung/{serieGuid}", null);
    }

    public async Task<FachzuordnungResultDTO> FachverteilungAsync(List<Guid> avGuids)
    {
        return await PutAsync<FachzuordnungResultDTO>("Ablage/Fachverteilung", avGuids);
    }
}

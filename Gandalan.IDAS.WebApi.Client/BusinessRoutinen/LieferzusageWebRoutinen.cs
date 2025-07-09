using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class LieferzusageWebRoutinen : WebRoutinenBase
{
    public LieferzusageWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<List<LieferzusageDTO>> GetAllZusagenAsync(Guid serie, string lieferant = "")
        => await GetAsync<List<LieferzusageDTO>>($"Lieferzusage/?serieGuid={serie}&lieferant={lieferant}");

    public async Task<int> GetZusagenCountAsync(Guid serie, string lieferant = "")
        => await GetAsync<int>($"Lieferzusage/GetCount/{serie}/{lieferant}");

    public async Task<string> MaterialZusagenAsync(LieferzusageDTO lieferzusage)
        => await PostAsync<string>("Lieferzusage", lieferzusage);

    public async Task<string> MaterialZusagenAsync(List<LieferzusageDTO> lieferzusagen)
        => await PostAsync<string>("Lieferzusage/PutLieferzusagenListe", lieferzusagen);

    public async Task ResetZusageAsync(Guid lieferzusageGuid)
        => await DeleteAsync($"Lieferzusage?zusageGuid={lieferzusageGuid}");

    public async Task<List<Guid>> ResetZusagenAsync(List<Guid> lieferzusagenGuids)
        => await DeleteAsync<List<Guid>>($"Lieferzusage/DeleteLieferzusagen", lieferzusagenGuids);
}

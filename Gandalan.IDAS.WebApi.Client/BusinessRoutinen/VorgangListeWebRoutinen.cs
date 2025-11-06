using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class VorgangListeWebRoutinen : WebRoutinenBase
{
    public VorgangListeWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(int jahr, bool includeASP = false, bool includeAdditionalProperties = false)
        => await GetAsync<VorgangListItemDTO[]>($"VorgangListe/?jahr={jahr}&includeASP={includeASP}&includeAdditionalProperties={includeAdditionalProperties}");

    public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(string status, int jahr, bool includeASP = false, bool includeAdditionalProperties = false)
        => await GetAsync<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}&includeASP={includeASP}&includeAdditionalProperties={{includeAdditionalProperties}}\"");

    public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(string status, int jahr, DateTime changedSince, bool includeASP = false, bool includeAdditionalProperties = false)
        => await GetAsync<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}&changedSince={changedSince:o}&includeASP={includeASP}&includeAdditionalProperties={{includeAdditionalProperties}}\"");

    public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "", bool includeASP = false, bool includeAdditionalProperties = false)
        => await GetAsync<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}&changedSince={changedSince:o}&art={art}&includeArchive={includeArchive}&includeOthersData={includeOthersData}&search={search}&includeASP={includeASP}&includeAdditionalProperties={includeAdditionalProperties}");

    public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(Guid kundeGuid)
        => await GetAsync<VorgangListItemDTO[]>($"VorgangListe/?kundeGuid={kundeGuid}");
}

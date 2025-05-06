using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class SaegeDatenHistorieWebRoutinen : WebRoutinenBase
{
    public SaegeDatenHistorieWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<SaegeDatenHistorieDTO> GetSaegeDatenHistorieAsync(Guid saegeDatenHistorieGuid, bool includeSaegeDatei = true,
        bool includeMeldungen = true)
    {
        var result = await GetAsync<IList<SaegeDatenHistorieDTO>>($"SaegeDatenHistorie/?saegeDatenHistorieGuid={saegeDatenHistorieGuid}&includeSaegeDatei={includeSaegeDatei}&includeMeldungen={includeMeldungen}");
        return result.FirstOrDefault();
    }

    public async Task<IList<SaegeDatenHistorieDTO>> GetSaegeDatenHistorieForSerieAsync(Guid serieGuid, bool includeSaegeDatei = false, bool includeMeldungen = false)
    => await GetAsync<IList<SaegeDatenHistorieDTO>>($"SaegeDatenHistorie/?serieGuid={serieGuid}&includeSaegeDatei={includeSaegeDatei}&includeMeldungen={includeMeldungen}");

    public async Task<IList<SaegeDatenHistorieDTO>> GetSaegeDatenHistorie(DateTime sinceWhen, bool includeSaegeDatei = false, bool includeMeldungen = false)
        => await GetAsync<IList<SaegeDatenHistorieDTO>>($"SaegeDatenHistorie/?createdSince={sinceWhen:o}&includeSaegeDatei={includeSaegeDatei}&includeMeldungen={includeMeldungen}");
}

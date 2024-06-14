using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class KapazitaetsberechnungWebRoutinen : WebRoutinenBase
{
    public KapazitaetsberechnungWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<Dictionary<Guid, decimal?>> GetKapazitaetAsync(List<Guid> positionGuids)
        => await PostAsync<Dictionary<Guid, decimal?>>("Kapaziaetsberechnung/GetKapaziaet", positionGuids);
    public async Task CalculateKapazitaetForFunctionAsync(Guid positionGuid, long mandantID)
        => await PostAsync($"Kapaziaetsberechnung/RunKapBerechnung?id={positionGuid}&mandantId={mandantID}", null);
    public async Task CalculateItemsAsync()
        => await PostAsync("Kapaziaetsberechnung/CalculateItems", null);
}
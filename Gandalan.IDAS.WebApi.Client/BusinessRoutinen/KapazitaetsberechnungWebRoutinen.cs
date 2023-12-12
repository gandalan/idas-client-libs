using Gandalan.IDAS.Client.Contracts.Contracts;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KapazitaetsberechnungWebRoutinen : WebRoutinenBase
    {
        public KapazitaetsberechnungWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task CalculateKapazitaetForFunctionAsync(Guid positionGuid, long mandantID) 
            => await PostAsync($"Kapaziaetsberechnung/RunKapBerechnung?id={positionGuid}&mandantId={mandantID}", null);
    }
}

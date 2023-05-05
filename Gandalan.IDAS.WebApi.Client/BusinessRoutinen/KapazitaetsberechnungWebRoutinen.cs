using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KapazitaetsberechnungWebRoutinen : WebRoutinenBase
    {
        public KapazitaetsberechnungWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
                
        public string CalculateKapazitaetForFunction(Guid positionGuid, long mandantID)
        {
            if (Login())
            {
                return Post($"Kapaziaetsberechnung/RunKapBerechnung?id={positionGuid}&mandantId={mandantID}", null);
            }
            return null;
        }

        public async Task CalculateKapazitaetForFunctionAsync(Guid positionGuid, long mandantID)
        {
            await Task.Run(() => CalculateKapazitaetForFunction(positionGuid, mandantID));
        }
    }
}

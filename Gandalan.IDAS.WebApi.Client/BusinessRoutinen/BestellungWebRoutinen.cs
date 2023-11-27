using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BestellungWebRoutinen : WebRoutinenBase
    {
        public BestellungWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task Bestellen(Guid bguid)
            => await PutAsync($"Bestellung/?bguid={bguid}", null);
    }
}

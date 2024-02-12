using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BenutzerVariantenWebRoutinen : WebRoutinenBase
    {
        public BenutzerVariantenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<VarianteDTO[]> GetBenutzerVariantenAsync(Guid benutzer, bool mitSperrliste)
            => await GetAsync<VarianteDTO[]>($"BenutzerVarianten?id={benutzer}&mitSperrliste={mitSperrliste}");
    }
}

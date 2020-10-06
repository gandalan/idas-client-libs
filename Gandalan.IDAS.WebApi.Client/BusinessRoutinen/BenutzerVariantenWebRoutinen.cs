using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BenutzerVariantenWebRoutinen : WebRoutinenBase
    {
        public BenutzerVariantenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public VarianteDTO[] GetBenutzerVarianten(Guid benutzer, bool mitSperrliste)
        {
            if (Login())
            {
                return Get<VarianteDTO[]>($"BenutzerVarianten?id={benutzer.ToString()}&mitSperrliste={mitSperrliste}");
            }
            return null;
        }


        public async Task<VarianteDTO[]> GetBenutzerVariantenAsync(Guid benutzer, bool mitSperrliste)
        {
            return await Task.Run(() => GetBenutzerVarianten(benutzer, mitSperrliste));
        }
    }
}

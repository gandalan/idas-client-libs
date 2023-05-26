using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using System.Diagnostics;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client
{
    public class MandantenWebRoutinen : WebRoutinenBase
    {
        public MandantenWebRoutinen(IWebApiConfig settings) : base(settings)
        {            
        }

        public async Task MandantenAbgleichen(List<MandantDTO> list)
        {
            list.ForEach(async (m) =>
            {
                await PutAsync("Mandanten", m);
            });
        }

        public async Task<MandantDTO> MandantenAnlegenAsync(MandantDTO mandant) 
            => await PutAsync<MandantDTO>("Mandanten", mandant);

        public async Task<List<MandantDTO>> LadeMandantenMitFilterAsync(string filter) 
            => await GetAsync<List<MandantDTO>>("Mandanten?filter=" + System.Uri.EscapeDataString(filter));
    }
}

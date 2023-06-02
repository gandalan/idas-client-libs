using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class WertelistenWebRoutinen : WebRoutinenBase
    {
        public WertelistenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<WerteListeDTO[]> GetAllAsync(bool includeAutoWerteListen) 
            => await GetAsync<WerteListeDTO[]>("WerteListe?includeAutoWerteListen=" + includeAutoWerteListen.ToString());

        public async Task<WerteListeDTO> GetAsync(Guid wertelisteGuid, bool includeAutoWerteListen = true)
            => await GetAsync<WerteListeDTO>($"WerteListe/{wertelisteGuid}?includeAutoWerteListen=" + includeAutoWerteListen.ToString());

        public async Task SaveAsync(WerteListeDTO dto)
            => await PutAsync("WerteListe/" + dto.WerteListeGuid.ToString(), dto);
    }
}

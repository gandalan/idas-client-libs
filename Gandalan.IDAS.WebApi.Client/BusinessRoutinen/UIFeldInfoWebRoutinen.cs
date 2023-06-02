using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class UIFeldInfoWebRoutinen : WebRoutinenBase
    {
        public UIFeldInfoWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public async Task<UIEingabeFeldInfoDTO[]> GetAllAsync()
            => await GetAsync<UIEingabeFeldInfoDTO[]>("UIEingabeFeldInfo");

        public async Task SaveUIEingabeFeldInfoAsync(UIEingabeFeldInfoDTO uiEingabeFeldInfo) 
            => await PutAsync<UIEingabeFeldInfoDTO>($"UIEingabeFeldInfo/{uiEingabeFeldInfo.UIEingabeFeldGuid}", uiEingabeFeldInfo);

        [Obsolete("Funktion 'SaveUIEingabeFeldInfo()' verwenden")]
        public async Task SaveAsync(UIEingabeFeldInfoDTO dto) 
            => await PutAsync($"UIEingabeFeldInfo/{dto.UIEingabeFeldGuid}", dto);
    }
}

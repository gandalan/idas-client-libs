using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

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

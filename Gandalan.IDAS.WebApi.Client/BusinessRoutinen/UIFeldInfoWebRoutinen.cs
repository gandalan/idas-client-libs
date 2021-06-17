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

        public UIEingabeFeldInfoDTO[] GetAll()
        {
            if (Login())
                return Get<UIEingabeFeldInfoDTO[]>("UIEingabeFeldInfo");
            throw new ApiException("Login fehlgeschlagen");
        }
        public UIEingabeFeldInfoDTO SaveUIEingabeFeldInfo(UIEingabeFeldInfoDTO uiEingabeFeldInfo)
        {
            if (Login())
                return Put<UIEingabeFeldInfoDTO>($"UIEingabeFeldInfo/{uiEingabeFeldInfo.UIEingabeFeldGuid}", uiEingabeFeldInfo);
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task SaveUIEingabeFeldInfoAsync(UIEingabeFeldInfoDTO uiEingabeFeldInfo) => await Task.Run(() => SaveUIEingabeFeldInfo(uiEingabeFeldInfo));
        public async Task<UIEingabeFeldInfoDTO[]> GetAllAsync() => await Task.Run(() => { return GetAll(); });

        [Obsolete("Funktion 'SaveUIEingabeFeldInfo()' verwenden")]
        public string Save(UIEingabeFeldInfoDTO dto)
        {
            if (Login())
            {
                return Put("UIEingabeFeldInfo/" + dto.UIEingabeFeldGuid.ToString(), dto);
            }
            return null;
        }
        [Obsolete("Funktion 'SaveUIEingabeFeldInfo()' verwenden")]
        public async Task SaveAsync(UIEingabeFeldInfoDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}

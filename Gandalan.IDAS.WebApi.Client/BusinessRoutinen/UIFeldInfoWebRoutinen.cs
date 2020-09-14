using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class UIFeldInfoWebRoutinen : WebRoutinenBase
    {
        public UIFeldInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public UIEingabeFeldInfoDTO[] GetAll()
        {
            if (Login())
            {
                return Get<UIEingabeFeldInfoDTO[]>("UIEingabeFeldInfo");
            }
            return null;
        }

        
        public string Save(UIEingabeFeldInfoDTO dto)
        {
            if (Login())
            {
                return Put("UIEingabeFeldInfo/" + dto.UIEingabeFeldGuid.ToString(), dto);
            }
            return null;
        }


        public async Task<UIEingabeFeldInfoDTO[]> GetAllAsync()
        {
            return await Task.Run(() => { return GetAll(); });
        }

        public async Task SaveAsync(UIEingabeFeldInfoDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}

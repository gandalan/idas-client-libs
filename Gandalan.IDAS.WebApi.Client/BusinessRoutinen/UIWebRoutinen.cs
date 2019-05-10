using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class UIWebRoutinen : WebRoutinenBase
    {
        public UIWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public UIDefinitionDTO[] GetAll()
        {
            if (Login())
            {
                return Get<UIDefinitionDTO[]>("UIDefinition?maxlevel=99");
            }
            return null;
        }

        
        public string Save(UIDefinitionDTO dto)
        {
            if (Login())
            {
                return Put("UIDefinition/" + dto.UIDefinitionGuid.ToString(), dto);
            }
            return null;
        }


        public async Task<UIDefinitionDTO[]> GetAllAsync()
        {
            return await Task.Run(() => { return GetAll(); });
        }

        public async Task SaveAsync(UIDefinitionDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}

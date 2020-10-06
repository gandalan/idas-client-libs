using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class UIScriptWebRoutinen : WebRoutinenBase
    {
        public UIScriptWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public UIScriptDTO[] GetAll()
        {
            if (Login())
            {
                return Get<UIScriptDTO[]>("UIScript/");
            }
            return null;
        }

        public UIScriptDTO getUIScript(string name)
        {
            if (Login())
            {
                return Get<UIScriptDTO>("UIScript?name=" + name);
            }
            return null;
        }

        public string Save(UIScriptDTO dto)
        {
            if (Login())
            {
                return Put("UIScript/", dto);
            }
            return null;
        }

        public string Delete(Guid guid)
        {
            if(Login())
            {
                return Delete("UIScript?guid=" + guid);
            }
            return null;
        }
        public string Delete()
        {
            if (Login())
            {
                return Delete("UIScript");
            }
            return null;
        }


        public async Task<UIScriptDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveAsync(UIScriptDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}

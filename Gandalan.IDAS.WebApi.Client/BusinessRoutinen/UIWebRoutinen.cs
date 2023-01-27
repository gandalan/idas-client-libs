using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class UIWebRoutinen : WebRoutinenBase
    {
        public UIWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public UIDefinitionDTO[] GetAll()
        {
            if (Login())
                return Get<UIDefinitionDTO[]>("UIDefinition?maxlevel=99");
            throw new ApiException("Login fehlgeschlagen");
        }
        public UIDefinitionDTO Get(Guid guid)
        {
            if (Login())
                return Get<UIDefinitionDTO>($"UIDefinition/Get?guid={guid}&maxlevel=99");
            throw new ApiException("Login fehlgeschlagen");
        }
        public UIDefinitionDTO SaveUIDefinition(UIDefinitionDTO uiDefinition)
        {
            if (Login())
                return Put<UIDefinitionDTO>($"UIDefinition/{uiDefinition.UIDefinitionGuid}", uiDefinition);
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task SaveUIDefinitionAsync(UIDefinitionDTO uiDefinition) => await Task.Run(() => SaveUIDefinition(uiDefinition));
        public async Task<UIDefinitionDTO> GetAsync(Guid guid) => await Task.Run(() => { return Get(guid); });
        public async Task<UIDefinitionDTO[]> GetAllAsync() => await Task.Run(() => { return GetAll(); });

        [Obsolete("Funktion 'SaveUIDefinition()' verwenden")]
        public string Save(UIDefinitionDTO dto)
        {
            if (Login())
            {
                return Put("UIDefinition/" + dto.UIDefinitionGuid.ToString(), dto);
            }
            return null;
        }
        [Obsolete("Funktion 'SaveUIDefinitionAsync()' verwenden")]
        public async Task SaveAsync(UIDefinitionDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}

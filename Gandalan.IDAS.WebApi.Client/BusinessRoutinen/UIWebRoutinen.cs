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

        public async Task<UIDefinitionDTO[]> GetAllAsync()
            => await GetAsync<UIDefinitionDTO[]>("UIDefinition?maxlevel=99");

        public async Task<UIDefinitionDTO> GetAsync(Guid guid)
            => await GetAsync<UIDefinitionDTO>($"UIDefinition/Get?guid={guid}&maxlevel=99");

        public async Task SaveUIDefinitionAsync(UIDefinitionDTO uiDefinition) 
            => await PutAsync<UIDefinitionDTO>($"UIDefinition/{uiDefinition.UIDefinitionGuid}", uiDefinition);

        [Obsolete("Funktion 'SaveUIDefinitionAsync()' verwenden")]
        public async Task SaveAsync(UIDefinitionDTO dto) 
            => await PutAsync("UIDefinition/" + dto.UIDefinitionGuid.ToString(), dto);
    }
}

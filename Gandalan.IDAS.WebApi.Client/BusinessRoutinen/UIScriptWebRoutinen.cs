using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class UIScriptWebRoutinen : WebRoutinenBase
{
    public UIScriptWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<UIScriptDTO[]> GetAllAsync()
        => await GetAsync<UIScriptDTO[]>("UIScript/");

    public async Task<UIScriptDTO> GetUIScript(string name)
        => await GetAsync<UIScriptDTO>("UIScript?name=" + name);

    public async Task SaveAsync(UIScriptDTO dto)
        => await PutAsync("UIScript/", dto);

    public async Task DeleteAsync(Guid guid)
        => await DeleteAsync("UIScript?guid=" + guid);
}
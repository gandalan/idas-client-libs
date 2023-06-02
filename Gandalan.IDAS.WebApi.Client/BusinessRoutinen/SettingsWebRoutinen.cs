using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SettingsWebRoutinen : WebRoutinenBase
    {
        public SettingsWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<Dictionary<string, ExpandoObject>> GetAllAsync() 
            => await GetAsync<Dictionary<string, ExpandoObject>>("Settings");

        public async Task SaveAsync(string key, ExpandoObject expandoObject)
            => await PutAsync($"Settings/{key}", expandoObject);
    }
}

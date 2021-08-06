using Gandalan.IDAS.Client.Contracts.Contracts;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SettingsWebRoutinen : WebRoutinenBase
    {
        public SettingsWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public Dictionary<string, ExpandoObject> GetAll()
        {
            if (Login())
            {
                return Get<Dictionary<string, ExpandoObject>>("Settings");
            }
            return null;
        }

        public string Save(string key, ExpandoObject expandoObject)
        {
            if (Login())
            {
                return Put("Settings/" + key, expandoObject);
            }
            return null;
        }

        public async Task<string>HTTPSaveAsync(string key, string json)
        {
            if (await HTTPLogin() != null)
                return await HTTPSendDataAsync(HttpMethod.Put, "Settings/" + key, json);

            return null;
        }

        public async Task<Dictionary<string, ExpandoObject>> GetAllAsync()
        {
            return await Task.Run(() => { return GetAll(); });
        }

        public async Task<Dictionary<string, ExpandoObject>> HTTPGetAllAsync()
        {
            if (HTTPLogin() != null)
                return await HTTPGet<Dictionary<string, ExpandoObject>>("Settings");

            return null;
        }

        public async Task SaveAsync(string key, ExpandoObject expandoObject)
        {
            await Task.Run(() => Save(key, expandoObject));
        }
    }
}

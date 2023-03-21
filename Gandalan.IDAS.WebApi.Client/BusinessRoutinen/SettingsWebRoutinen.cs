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


        public async Task<Dictionary<string, ExpandoObject>> GetAllAsync()
        {
            return await Task.Run(() => { return GetAll(); });
        }


        public async Task SaveAsync(string key, ExpandoObject expandoObject)
        {
            await Task.Run(() => Save(key, expandoObject));
        }
    }
}

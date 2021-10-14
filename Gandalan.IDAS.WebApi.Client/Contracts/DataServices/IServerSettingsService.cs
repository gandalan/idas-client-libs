using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IServerSettingsService
    {
        Task<Dictionary<string, ExpandoObject>> GetAllAsync();
        Task SaveAsync(string key, ExpandoObject expandoObject);
    }
}

using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices;

public interface IServerSettingsService
{
    Task<Dictionary<string, ExpandoObject>> GetAllAsync();
    Task SaveAsync(string key, ExpandoObject expandoObject);
}
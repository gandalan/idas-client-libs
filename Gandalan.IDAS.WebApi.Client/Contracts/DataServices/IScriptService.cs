using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices;

public interface IScriptService
{
    Task<Dictionary<string, string>> GetAllAsync();
    Task Clean();
}
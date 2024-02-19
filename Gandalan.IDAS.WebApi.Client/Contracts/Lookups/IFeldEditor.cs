using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.Lookups
{
    public interface IFeldEditor
    {
        bool CanHandle(BelegPositionDTO data, string tag, bool initGroup = false);
        Task<Dictionary<string, string>> ExecuteAsync(BelegPositionDTO data);
    }

    public interface IFeldEditor<T> : IFeldEditor where T : class
    {
        void Init(T data);
    }
}

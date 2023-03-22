using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts
{
    public interface IStore<T> where T : new()
    {
        Task<T> GetAsync(Guid guid);

        Task AddOrUpdateAsync(T data);

        Task<IList<T>> GetAllAsync();

        Task DeleteAsync(Guid guid);

        Task<bool> ExistsAsync(Guid guid);
    }
}

using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Cache
{
    public interface ICache<T> where T : new()
    {
        void PutItem(string identifier, T data);
        Task<T> GetItem<T>(string identifier, DateTime? expirationDate, Func<Task<T>> retrieveDataIfCacheMiss);
        void Clear(string identifier);
    }
}
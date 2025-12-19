using System;
using System.IO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Cache;

public interface IFileCache
{
    Task PutFile(string identifier, Stream ms);
    Task PutFile(string identifier, byte[] bytes);
    Task<byte[]> GetFile(string identifier, DateTime? expirationDate, Func<Task<byte[]>> retrieveDataIfCacheMiss);
    Task<string> GetFilePath(string identifier, DateTime? expirationDate, Func<Task<byte[]>> retrieveDataIfCacheMiss);
    void Clear(string identifier);
}

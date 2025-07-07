using System;
using System.IO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Cache;

public interface IDocumentCache
{
    Task PutDocument(string identifier, Stream ms);
    Task PutDocument(string identifier, byte[] bytes);
    Task<byte[]> GetDocument(string identifier, DateTime? expirationDate, Func<Task<byte[]>> retrieveDataIfCacheMiss);
    void Clear(string identifier);
}

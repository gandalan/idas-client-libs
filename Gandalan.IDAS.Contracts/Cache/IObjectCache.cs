using System;

namespace Gandalan.IDAS.Contracts.Cache;

public interface IObjectCache
{
    void Clear(Guid context, string identifier = null);
    T GetItem<T>(Guid context, string identifier, DateTime? expirationDate = null);
    IObjectCacheItemInfo<T> QueryItem<T>(Guid context, string identifier, DateTime? expirationDate = null, bool includeObjectIfExists = false);
    void PutItem(Guid context, string identifier, object data);
}

public interface IObjectCacheItemInfo<T>
{
    bool IsExpired { get; set; }
    T Item { get; }
    DateTime CacheTime { get; }
}

public class ObjectCacheItemInfo<T> : IObjectCacheItemInfo<T>
{
    public T Item { get; set; }
    public DateTime CacheTime { get; set; }
    public bool IsExpired { get; set; }
}
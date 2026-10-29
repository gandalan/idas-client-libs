using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.Contracts.Cache;

public interface IObjectCache
{
    void Clear(Guid context, string identifier = null);
    T GetItem<T>(Guid context, string identifier, DateTime? expirationDate = null);

    /// <summary>
    /// Liest mehrere Einträge eines Kontexts auf einmal. Identifier ohne Eintrag fehlen im Ergebnis.
    /// </summary>
    IReadOnlyDictionary<string, T> GetItems<T>(Guid context, IEnumerable<string> identifiers);
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
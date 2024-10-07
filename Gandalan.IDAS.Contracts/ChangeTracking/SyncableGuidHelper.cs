using System.Collections.Generic;
using System.Reflection;
using Gandalan.IDAS.Contracts.ChangeTracking;

namespace System;

public static class SyncableGuidHelper
{
    private static readonly Dictionary<Type, PropertyInfo> _guidProperties = [];

    public static Guid GetGuid(this object o)
    {
        if (o is Guid guid)
        {
            return guid;
        }

        var guidProperty = GetGuidProperty(o.GetUnproxiedType());
        return guidProperty != null ? (Guid)guidProperty.GetValue(o, null) : Guid.Empty;
    }

    public static Guid TryGetGuid(this object o)
    {
        if (o is Guid guid)
        {
            return guid;
        }

        var guidProperty = TryGetGuidProperty(o.GetUnproxiedType());
        return guidProperty != null ? (Guid)guidProperty.GetValue(o, null) : Guid.Empty;
    }

    public static void SetGuid(this object o, Guid newSyncableGuid)
    {
        var guidProperty = GetGuidProperty(o.GetUnproxiedType());
        guidProperty?.SetValue(o, newSyncableGuid, null);
    }

    public static PropertyInfo GetGuidProperty(Type t)
    {
        lock (_guidProperties)
        {
            if (!_guidProperties.ContainsKey(t))
            {
                string propertyName;
                var attrib = t.GetCustomAttribute<SyncableAttribute>(true);
                if (attrib != null)
                {
                    propertyName = attrib.GuidColumnName;
                }
                else if (t.Name.Contains("DTO"))
                {
                    propertyName = $"{t.Name.Replace("DTO", "")}Guid";
                }
                else
                {
                    throw new InvalidOperationException("Entität hat kein Syncable-Attribut");
                }

                if (!string.IsNullOrEmpty(propertyName))
                {
                    var guidProperty = t.GetProperty(propertyName) ?? throw new InvalidOperationException($"Spalte {propertyName} nicht in Typ {t.FullName} enthalten");
                    if (guidProperty.PropertyType != typeof(Guid))
                    {
                        throw new InvalidOperationException($"Spalte {propertyName} in Typ {t.FullName} ist keine Guid");
                    }

                    _guidProperties.Add(t, guidProperty);
                }
                else
                {
                    throw new InvalidOperationException("Spalte mit Guid nicht gefunden");
                }
            }
        }

        lock (_guidProperties)
        {
            return _guidProperties[t];
        }
    }

    public static PropertyInfo TryGetGuidProperty(Type t)
    {
        lock (_guidProperties)
        {
            if (!_guidProperties.ContainsKey(t))
            {
                var attrib = t.GetCustomAttribute<SyncableAttribute>(true);
                string propertyName;
                if (attrib != null)
                {
                    propertyName = attrib.GuidColumnName;
                }
                else if (t.Name.Contains("DTO"))
                {
                    propertyName = $"{t.Name.Replace("DTO", "")}Guid";
                }
                else
                {
                    propertyName = $"{t.Name}Guid";
                }

                if (!string.IsNullOrEmpty(propertyName))
                {
                    var guidProperty = t.GetProperty(propertyName);
                    if (guidProperty == null)
                    {
                        return null;
                    }

                    if (guidProperty.PropertyType != typeof(Guid))
                    {
                        throw new InvalidOperationException($"Spalte {propertyName} in Typ {t.FullName} ist keine Guid");
                    }

                    _guidProperties.Add(t, guidProperty);
                }
                else
                {
                    throw new InvalidOperationException("Spalte mit Guid nicht gefunden");
                }
            }
        }

        lock (_guidProperties)
        {
            return _guidProperties[t];
        }
    }

    public static bool IsSyncable(this object o)
    {
        return o.GetType().GetCustomAttribute<SyncableAttribute>(true) != null;
    }

    public static bool IsSyncable(this Type t)
    {
        return t.GetCustomAttribute<SyncableAttribute>(true) != null;
    }
}

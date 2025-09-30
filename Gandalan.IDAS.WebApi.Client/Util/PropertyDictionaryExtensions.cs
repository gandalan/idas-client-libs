using System;
using System.Collections.Generic;
using System.Globalization;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.Client.Util;

public static class PropertyDictionaryExtensions
{
    public static void SetProperty<T>(this Dictionary<string, PropertyValueCollection> properties, string subObjectName, string key, T value)
    {
        if (properties == null)
        {
            return;
        }

        if (!properties.TryGetValue(subObjectName, out var subObj))
        {
            subObj = [];
            properties.Add(subObjectName, subObj);
        }

        subObj[key] = value;
    }

    public static T GetProperty<T>(this Dictionary<string, PropertyValueCollection> properties, string subObjectName, string key, T defaultValue = default)
    {
        if (properties == null || properties.Count == 0 || !properties.TryGetValue(subObjectName, out var subObj) || !subObj.ContainsKey(key))
        {
            return defaultValue;
        }

        var underlyingT = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

        var value = properties[subObjectName][key] == null
            ? defaultValue
            : Convert.ChangeType(properties[subObjectName][key], underlyingT, CultureInfo.InvariantCulture);

        return (T)value;
    }

    public static PropertyValueCollection GetSubObject(this Dictionary<string, PropertyValueCollection> properties, string subObjectName)
    {
        if (properties == null || properties.Count == 0 || !properties.TryGetValue(subObjectName, out var subObject))
        {
            return null;
        }

        return subObject;
    }

    public static PropertyValueCollection DeleteSubObject(this Dictionary<string, PropertyValueCollection> properties,
        string subObjectName)
    {
        if (properties == null || properties.Count == 0 || !properties.TryGetValue(subObjectName, out var subObject))
        {
            return null;
        }

        properties?.Remove(subObjectName);
        return subObject;
    }

    public static void SetSubObject(this Dictionary<string, PropertyValueCollection> properties, string subObjectName, PropertyValueCollection subObject)
    {
        if (properties == null)
        {
            return;
        }

        properties ??= [];
        properties[subObjectName] = subObject;
    }
}

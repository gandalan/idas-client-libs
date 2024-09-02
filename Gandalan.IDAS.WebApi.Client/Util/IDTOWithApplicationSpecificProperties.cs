using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Util;

public interface IDTOWithApplicationSpecificProperties
{
    Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
}

public interface IEntityWithApplicationSpecificProperties
{
}

public static class AppSpecificPropertiesExtensions
{
    public static T GetSetting<T>(this IDTOWithApplicationSpecificProperties dto, string key, T defaultValue = default)
    {
        return GetSetting(dto, "settings", key, defaultValue);
    }

    public static T GetSetting<T>(this IDTOWithApplicationSpecificProperties dto, string subObjectName, string key, T defaultValue = default)
    {
        var properties = dto?.ApplicationSpecificProperties;
        if (properties == null || properties.Count == 0 || !properties.TryGetValue(subObjectName, out var subObj) || !subObj.ContainsKey(key))
        {
            return defaultValue;
        }

        // to avoid InvalidCastException in Convert.ChangeType we need to change to the underlying type of nullable types
        var underlyingT = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        // if the property value is null => defaultValue
        // else change type to underlying type
        var value = properties[subObjectName][key] == null
            ? defaultValue
            : Convert.ChangeType(properties[subObjectName][key], underlyingT);
        // back to the original type
        return (T)value;
    }

    public static PropertyValueCollection GetSubObject(this IDTOWithApplicationSpecificProperties dto, string subObjectName)
    {
        var properties = dto.ApplicationSpecificProperties;
        if (properties == null || properties.Count == 0 || !properties.TryGetValue(subObjectName, out var subObject))
        {
            return null;
        }

        return subObject;
    }

    public static void SetSubObject(this IDTOWithApplicationSpecificProperties dto, string subObjectName, PropertyValueCollection subObject)
    {
        var properties = dto.ApplicationSpecificProperties;
        if (properties == null) //noch kein Objekt für die properties
        {
            properties = dto.ApplicationSpecificProperties = [];
        }

        properties[subObjectName] = subObject;
    }

    public static void SetSetting<T>(this IDTOWithApplicationSpecificProperties dto, string key, T value)
    {
        SetSetting(dto, "settings", key, value);
    }

    public static void DeleteSetting(this IDTOWithApplicationSpecificProperties dto, string key)
    {
        const string prefix = "settings";
        var properties = dto.ApplicationSpecificProperties;
        if (properties == null) //noch kein Objekt für die properties, nichts zu löschen
        {
            return;
        }

        if (properties.Count == 0 || !properties.TryGetValue(prefix, out var property)) //wenn keine properties vorhanden oder noch keine settings da, nichts zu löschen
        {
            return;
        }

        if (!property.ContainsKey(key))
        {
            return; // key nicht vorhanden, nichts zu löschen
        }

        properties[prefix].Remove(key);
    }

    public static void SetSetting<T>(this IDTOWithApplicationSpecificProperties dto, string subObjectName, string key, T value)
    {
        var properties = dto.ApplicationSpecificProperties;

        //prüfen ob es überhaupt schon properties gibt
        if (properties == null) //noch kein Objekt für die properties
        {
            properties = dto.ApplicationSpecificProperties = [];
        }

        //prüfen ob es überhaupt properties gibt und auch ob es einen für settings gibt
        if (!properties.TryGetValue(subObjectName, out var subObj)) //wenn keine properties vorhanden oder noch keine settings da, dann schreiben wir das neue property
        {
            subObj = ([]);
            properties.Add(subObjectName, subObj);
        }

        //prüfen ob es favorite schon gibt, falls nicht fügen wir es hinzu
        if (!subObj.ContainsKey(key))
        {
            subObj.Add(key, value);
        }
        else
        {
            subObj[key] = value;
        }
    }
}


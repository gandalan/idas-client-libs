using Gandalan.IDAS.WebApi.Client.Util;

namespace Gandalan.IDAS.WebApi.Util;

/// <summary>
/// Handle the ApplicationSpecificProperties of a DTO.
/// Includes methods to manage subobjects and key/value pairs, both from the generic "settings" subobject
/// as well as any other subojects of an application.
///
/// The GetSetting, SetSetting, and DeleteSettings methods are convenience methods to handle the "settings"
/// subobject.
/// </summary>
public static class AppSpecificPropertiesExtensions
{
    /// <summary>
    /// Get a single key/value pair from the settings subobject of the ApplicationSpecificProperties
    /// </summary>
    /// <typeparam name="T">type of the value</typeparam>
    /// <param name="dto">instance to extend</param>
    /// <param name="key">setting key within "settings" subobject</param>
    /// <param name="defaultValue">setting value</param>
    /// <returns></returns>
    public static T GetSetting<T>(this IDTOWithApplicationSpecificProperties dto, string key, T defaultValue = default)
    {
        return GetProperty(dto, "settings", key, defaultValue);
    }

    /// <summary>
    /// Set a single key/value pair in the settings subobject of the ApplicationSpecificProperties
    /// </summary>
    /// <typeparam name="T">type of the value to set</typeparam>
    /// <param name="dto">instance to extend</param>
    /// <param name="key">key identifier to write to</param>
    /// <param name="value">value to write</param>
    public static void SetSetting<T>(this IDTOWithApplicationSpecificProperties dto, string key, T value)
    {
        SetProperty(dto, "settings", key, value);
    }

    /// <summary>
    /// Delete a single key/value pair from the settings subobject of the ApplicationSpecificProperties
    /// </summary>
    /// <param name="dto">instance to extend</param>
    /// <param name="key">key identifier to delete, if it exists</param>
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

    /// <summary>
    /// Gets a value from the "public" subobject of the ApplicationSpecificProperties. Public subobjects are
    /// be visible across all applications.
    /// </summary>
    /// <typeparam name="T">type of the value to store</typeparam>
    /// <param name="dto">instance to extend</param>
    /// <param name="key">key identifier to write to</param>
    /// <param name="defaultValue">default value, if value doesn't exist</param>
    /// <returns>requested value or default value, if it doesn't exist</returns>
    public static T GetPublicProperty<T>(this IDTOWithApplicationSpecificProperties dto, string key, T defaultValue = default)
    {
        return GetProperty(dto, "public", key, defaultValue);
    }

    /// <summary>
    /// Sets a value in the "public" subobject of the ApplicationSpecificProperties. Public subobjects are
    /// visible across all applications.
    /// </summary>
    /// <typeparam name="T">type of the value to store</typeparam>
    /// <param name="dto">instance to extend</param>
    /// <param name="key">key identifier to write to</param>
    /// <param name="value">value to write</param>
    public static void SetPublicProperty<T>(this IDTOWithApplicationSpecificProperties dto, string key, T value)
    {
        SetProperty(dto, "public", key, value);
    }

    /// <summary>
    /// Deletes a public property
    /// </summary>
    /// <param name="dto">instance to extend</param>
    /// <param name="key">key identifier to write to</param>
    public static void DeletePublicProperty(this IDTOWithApplicationSpecificProperties dto, string key)
    {
        const string prefix = "public";
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

    /// <summary>
    /// Set a single key/value pair in a named subobject of the ApplicationSpecificProperties
    /// </summary>
    /// <typeparam name="T">type of the value to set</typeparam>
    /// <param name="dto">instance to extend</param>
    /// <param name="subObjectName">name of the subobject that contains the value</param>
    /// <param name="key">key identifier for the property</param>
    /// <param name="value">value to write</param>
    public static void SetProperty<T>(this IDTOWithApplicationSpecificProperties dto, string subObjectName, string key, T value)
    {
        var properties = dto.ApplicationSpecificProperties;

        if (properties == null)
        {
            properties = dto.ApplicationSpecificProperties = [];
        }

        properties.SetProperty(subObjectName, key, value);
    }

    /// <summary>
    /// Get a single key/value pair from a named subobject of the ApplicationSpecificProperties
    /// </summary>
    /// <typeparam name="T">type of the value to retrieve</typeparam>
    /// <param name="dto">instance to extend</param>
    /// <param name="subObjectName">name of the subobject that contains the value</param>
    /// <param name="key">key identifier for the property</param>
    /// <param name="defaultValue">default value of the property (returned if property doesn't exist)</param>
    /// <returns></returns>
    public static T GetProperty<T>(this IDTOWithApplicationSpecificProperties dto, string subObjectName, string key, T defaultValue = default)
    {
        return dto?.ApplicationSpecificProperties != null
            ? dto.ApplicationSpecificProperties.GetProperty(subObjectName, key, defaultValue)
            : defaultValue;
    }

    /// <summary>
    /// Get a subobject, containing a dictionary of key/value pairs, from the ApplicationSpecificProperties
    /// </summary>
    /// <param name="dto">instance to extend</param>
    /// <param name="subObjectName">subobject to retrieve</param>
    /// <returns></returns>
    public static PropertyValueCollection GetSubObject(this IDTOWithApplicationSpecificProperties dto, string subObjectName)
    {
        return dto.ApplicationSpecificProperties.GetSubObject(subObjectName);
    }

    /// <summary>
    /// Set a subobject, containing a dictionary of key/value pairs, in the ApplicationSpecificProperties
    /// </summary>
    /// <param name="dto">instance to extend</param>
    /// <param name="subObjectName">subobject to replace</param>
    /// <param name="subObject">subobject data</param>
    public static void SetSubObject(this IDTOWithApplicationSpecificProperties dto, string subObjectName, PropertyValueCollection subObject)
    {
        dto.ApplicationSpecificProperties.SetSubObject(subObjectName, subObject);
    }
}

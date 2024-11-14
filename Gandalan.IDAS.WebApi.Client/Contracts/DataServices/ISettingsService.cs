using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices;

public interface ISettingsService
{
    Task<T> Load<T>() where T : new();
    Task<T> LoadOrDefault<T>();
    Task Load<T>(T settingsObject);
    Task Save<T>(T settingsObject);
    bool IstReady();
    Task<Dictionary<string, string>> GetAllSettings(SettingsType type);
    bool HasSetting(string name);
}

public enum SettingsType
{
    User,
    App,
    Server
}

public class UserSettingsObjectAttribute : Attribute
{
    private readonly bool _isUserSettingsObject;

    public UserSettingsObjectAttribute()
    {
        _isUserSettingsObject = true;
    }

    public UserSettingsObjectAttribute(bool isLocalObject)
    {
        _isUserSettingsObject = isLocalObject;
    }

    public bool IsLocalObject => _isUserSettingsObject;
}

public class AppSettingsObjectAttribute : Attribute
{
    private readonly bool _isAppSettingObject;

    public AppSettingsObjectAttribute()
    {
        _isAppSettingObject = true;
    }

    public AppSettingsObjectAttribute(bool isLocalObject)
    {
        _isAppSettingObject = isLocalObject;
    }

    public bool IsAppSettingObject => _isAppSettingObject;
}

public class SettingsKeyAttribute : Attribute
{
    private readonly string _keyName;

    public SettingsKeyAttribute(string keyName)
    {
        _keyName = keyName;
    }

    public string KeyName => _keyName;
}

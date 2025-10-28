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
    Task<Dictionary<string, string>> LoadAllSettings(SettingsType type);
    bool HasSetting(string name);
}

public enum SettingsType
{
    User,
    App,
    Server
}

[AttributeUsage(AttributeTargets.Class)]
public class UserSettingsObjectAttribute(bool isLocalObject) : Attribute
{
    public UserSettingsObjectAttribute() : this(true)
    {
    }

    public bool IsLocalObject => isLocalObject;
}

[AttributeUsage(AttributeTargets.Class)]
public class AppSettingsObjectAttribute(bool isLocalObject) : Attribute
{
    public AppSettingsObjectAttribute() : this(true)
    {
    }

    public bool IsAppSettingObject => isLocalObject;
}

[AttributeUsage(AttributeTargets.Class)]
public class SettingsKeyAttribute(string keyName) : Attribute
{
    public string KeyName => keyName;
}

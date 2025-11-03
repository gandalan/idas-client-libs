using System;

namespace Gandalan.Client.Contracts.DataServices;

[AttributeUsage(AttributeTargets.Class)]
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

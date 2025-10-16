using System;

namespace Gandalan.Client.Contracts.DataServices;

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

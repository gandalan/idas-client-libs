using System;

namespace Gandalan.Client.Contracts.DataServices;

public class SettingsKeyAttribute : Attribute
{
    private readonly string _keyName;

    public SettingsKeyAttribute(string keyName)
    {
        _keyName = keyName;
    }

    public string KeyName => _keyName;
}

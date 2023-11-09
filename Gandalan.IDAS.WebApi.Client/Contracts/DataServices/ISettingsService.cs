using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface ISettingsService
    {        
        Task<T> Load<T>() where T : new();
        Task Load<T>(T settingsObject);
        Task Save(object settingsObject);
        bool IstReady();
    }

    public class LocalSettingsObjectAttribute : Attribute
    {
        private readonly bool _isLocalObject;

        public LocalSettingsObjectAttribute()
        {
            _isLocalObject = true;
        }

        public LocalSettingsObjectAttribute(bool isLocalObject)
        {
            _isLocalObject = isLocalObject;
        }

        public bool IsLocalObject => _isLocalObject;
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
}

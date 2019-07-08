using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface ISettingsService
    {        
        Task<T> Load<T>();
        Task Save(object settingsObject);

        /*
Task SaveSettings();
Task LoadSettings();
dynamic this[string key] { get; set; }
IEnumerable<string> GetKeys();

void SetSettingsValue(string context, string valueName, object value);

decimal GetSettingsValue(string context, string key, decimal defaultValue);
long GetSettingsValue(string context, string key, long defaultValue);
int GetSettingsValue(string context, string key, int defaultValue);
bool GetSettingsValue(string context, string key, bool defaultValue);
string GetSettingsValue(string context, string key, string defaultValue);
double GetSettingsValue(string context, string key, double defaultValue);
DateTime GetSettingsValue(string v1, string v2, DateTime minValue);
*/
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

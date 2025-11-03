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

namespace Gandalan.Client.Contracts.UIServices;

public interface ISettingsModul
{
    string Name { get; }
    string Beschreibung { get; }
    object Control { get; }
    SettingsCategory Category { get; }

    bool HasErrors();
    void SetData(object data);
}

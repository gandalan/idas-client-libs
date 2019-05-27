namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface ISettingsModul
    {
        string Name { get; }
        string Beschreibung { get; }
        object Control { get; }
        bool HasErrors();
        void SetData(object data);
        int OrderId { get; }
    }
}

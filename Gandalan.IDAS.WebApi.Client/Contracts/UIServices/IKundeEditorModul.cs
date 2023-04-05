namespace Gandalan.Client.Contracts.UIServices
{
    public interface IKundeEditorModul
    {
        string Header { get; }
        object Control { get; }
        bool HasErrors();
        void SetData(object data);
        void OnCancelledSave();
        int OrderId { get; }
    }
}

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IKundeEditorModul
    {
        string Header { get; }
        object Control { get; }
        bool HasErrors();
        void SetData(object data);
        int OrderId { get; }
    }
}

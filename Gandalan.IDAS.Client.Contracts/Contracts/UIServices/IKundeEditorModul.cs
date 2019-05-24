using System.Windows.Controls;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IKundeEditorModul
    {
        string Header { get; }
        UserControl Control { get; }
        bool HasErrors();
        void SetData(object data);
        int OrderId { get; }
    }
}

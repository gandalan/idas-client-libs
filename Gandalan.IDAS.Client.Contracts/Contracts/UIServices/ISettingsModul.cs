using System.Windows.Controls;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface ISettingsModul
    {
        string Name { get; }
        string Beschreibung { get; }
        UserControl Control { get; }
        bool HasErrors();
        void SetData(object data);
        int OrderId { get; }
    }
}

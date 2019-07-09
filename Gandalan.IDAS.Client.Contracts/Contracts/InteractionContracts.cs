using System.ComponentModel;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts
{
    public interface IInteractivePanel : INotifyPropertyChanged
    {
        string Caption { get; }    
        bool IsLoading { get; }
    }

    public interface IEditorPanel : IInteractivePanel
    {
        Task<bool> Save();
        bool Cancel();
        bool Pause();
        bool PausePossible { get; }
    }

    public interface IDisplayPanel : IInteractivePanel
    {     
    }

    public interface ILookupDialog<T, U>
    {
        T Execute(U data);
    }

    public interface IQuickEditDialog<T>
    {
        T Execute();
    }
}

using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts
{
    public interface IInteractivePanel : INotifyPropertyChanged
    {
        string Caption { get; }    
        bool IsLoading { get; }
        Task OnLoadAsync(object sender, EventArgs e);
        Task OnUnLoadAsync(object sender, EventArgs e);
        Task CleanupToDispose();
    }

    public interface IEditorPanel : IInteractivePanel
    {
        Task<bool> Save();
        bool Cancel();
        bool Pause();
        bool PausePossible { get; }
        bool SavePossible { get; }
        bool CancelPossible { get; }
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

    public interface IDirtyFlag
    {
        bool IsDirty { get; }
    }
}

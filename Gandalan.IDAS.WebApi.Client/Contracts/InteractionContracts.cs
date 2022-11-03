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
    }

    public interface IEditorPanel : IInteractivePanel
    {
        Task<bool> Save();
        bool Cancel();
        bool SavePossible { get; }
        bool CancelPossible { get; }
    }

    public interface ISaveAndContinue
    {
        Task<bool> SaveAndContinue();
    }

    public interface ISaveAndNew
    {
        Task<bool> SaveAndNew();
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

using System;
using System.ComponentModel;
using System.Windows.Input;
using Gandalan.IDAS.WebApi.DTO;
using PropertyChanged;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge;

public abstract class IVorgangCommand : ICommand, INotifyPropertyChanged
{
    public abstract event EventHandler CanExecuteChanged;
    public event PropertyChangedEventHandler PropertyChanged;

    [SuppressPropertyChangedWarnings]
    public abstract string Caption { get; set; }
    [SuppressPropertyChangedWarnings]
    public abstract string ToolTip { get; set; }

    public bool IsExecuting { get; set; }

    public bool CanExecute(object parameter)
    {
            var vorgang = parameter as VorgangDTO;
            if (parameter == null)
            {
                return false;
            }

            return CanExecute(vorgang);
        }

    public abstract bool CanExecute(VorgangDTO vorgang);

    public void Execute(object parameter)
    {
            if (parameter is not VorgangDTO vorgang)
            {
                throw new ArgumentException("Parameter muss ein VorgangDTO sein", nameof(parameter));
            }

            Execute(vorgang);
        }

    public abstract void Execute(VorgangDTO vorgang);
}
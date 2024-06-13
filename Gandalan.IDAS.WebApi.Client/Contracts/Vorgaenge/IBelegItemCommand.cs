using System;
using System.Windows.Input;

namespace Gandalan.IDAS.Client.Contracts.Vorgaenge;

public abstract class IBelegItemCommand : ICommand
{
    public abstract event EventHandler CanExecuteChanged;

    public abstract bool CanExecute(IBelegAuswahlItem parameter);
    public bool CanExecute(object parameter)
    {
            if (parameter is not IBelegAuswahlItem pos)
            {
                return false;
            }

            return CanExecute(pos);
        }

    public abstract void Execute(IBelegAuswahlItem parameter);
    public void Execute(object parameter)
    {
            if (parameter is not IBelegAuswahlItem pos)
            {
                throw new ArgumentException("Parameter muss eine Belegposition sein", nameof(parameter));
            }

            Execute(pos);
        }

    /// <summary>
    /// Wird als Content in den Buttons angezeigt.
    /// </summary>
    public object Caption { get; set; } = "?";
    public string Tooltip { get; set; } = "";
}
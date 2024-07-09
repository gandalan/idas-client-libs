using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Gesamtbedarf;

public abstract class IGesamtbedarfFehllisteCommand : ICommand, INotifyPropertyChanged
{
    public abstract event EventHandler CanExecuteChanged;
    public event PropertyChangedEventHandler PropertyChanged;

    public abstract bool CanExecute(IGesamtbedarfListe parameter);
    public bool CanExecute(object parameter)
    {
        if (parameter is not IGesamtbedarfListe pos)
        {
            return false;
        }

        return CanExecute(pos);
    }

    /// <summary>
    /// Returns wherever this command should be shown or not.
    /// Sometimes a position should not show some commands if they are not allowed
    /// </summary>
    public abstract bool CanHandle(IGesamtbedarfListe parameter);
    public bool CanHandle(object parameter)
    {
        if (parameter is not IGesamtbedarfListe pos)
        {
            return false;
        }

        return CanExecute(pos);
    }

    public abstract void Execute(IGesamtbedarfListe parameter);
    public void Execute(object parameter)
    {
        if (parameter is not IGesamtbedarfListe pos)
        {
            throw new ArgumentException("Parameter muss eine Liste von IGesamtMaterialbedarfItem sein", nameof(parameter));
        }

        Execute(pos);
    }

    /// <summary>
    /// Wird als Content in den Buttons angezeigt.
    /// </summary>
    public object Caption { get; set; } = "?";
    public string Tooltip { get; set; } = "";
}

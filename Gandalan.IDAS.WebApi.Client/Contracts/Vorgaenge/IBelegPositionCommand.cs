using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Gandalan.IDAS.Client.Contracts.Vorgaenge
{
    public abstract class IBelegPositionCommand : ICommand, INotifyPropertyChanged
    {
        public abstract event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract bool CanExecute(IBelegPositionItem parameter);
        public bool CanExecute(object parameter)
        {
            var pos = parameter as IBelegPositionItem;
            if (pos == null)
                return false;
            return CanExecute(pos);
        }

        /// <summary>
        /// Returns wherever this command should be shown or not. 
        /// Sometimes a position should not show some commands if they are not allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract bool CanHandle(IBelegPositionItem parameter);
        public bool CanHandle(object parameter)
        {
            var pos = parameter as IBelegPositionItem;
            if (pos == null)
                return false;
            return CanExecute(pos);
        }

        public abstract void Execute(IBelegPositionItem parameter);
        public void Execute(object parameter)
        {
            var pos = parameter as IBelegPositionItem;
            if (pos == null)
                throw new ArgumentNullException("Parameter muss eine Belegposition sein");
            Execute(pos);
        }

        /// <summary>
        /// Wird als Content in den Buttons angezeigt.
        /// </summary>
        public object Caption { get; set; } = "?";
        public string Tooltip { get; set; } = "";
    }
}

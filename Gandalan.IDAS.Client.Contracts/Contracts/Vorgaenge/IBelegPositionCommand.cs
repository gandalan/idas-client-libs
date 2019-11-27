using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Vorgaenge
{
    public abstract class IBelegPositionCommand : ICommand
    {
        public abstract event EventHandler CanExecuteChanged;       
        
        public abstract bool CanExecute(IBelegPositionItem parameter);
        public bool CanExecute(object parameter)
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

        public string Caption { get; set; } = "?";
        public string Tooltip { get; set; } = "";
        public bool IstAktiv { get; set; }
    }
}

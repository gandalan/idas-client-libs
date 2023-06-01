using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge
{
    public abstract class IVorgangCommand : ICommand, INotifyPropertyChanged
    {
        public abstract event EventHandler CanExecuteChanged;
#pragma warning disable CS0067 // The event 'IVorgangCommand.PropertyChanged' is never used
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067 // The event 'IVorgangCommand.PropertyChanged' is never used

        public abstract string Caption { get; set; }
        public abstract string ToolTip { get; set; }

        public bool IsExecuting { get; set; } = false;

        public bool CanExecute(object parameter)
        {
            var vorgang = parameter as VorgangDTO;
            if (parameter == null)
                return false;
            return CanExecute(vorgang);
        }

        public abstract bool CanExecute(VorgangDTO vorgang);

        public void Execute(object parameter)
        {
            var vorgang = parameter as VorgangDTO;
            if (parameter == null)
            {
                throw new ArgumentNullException("Parameter muss ein VorgangDTO sein");
            }
            Execute(vorgang);
        }

        public abstract void Execute(VorgangDTO vorgang);
    }
}

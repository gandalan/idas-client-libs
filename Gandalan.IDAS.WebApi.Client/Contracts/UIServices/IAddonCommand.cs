using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Gandalan.IDAS.WebApi.Client.Contracts.UIServices
{
    public abstract class IAddonCommand : ICommand, INotifyPropertyChanged
    {
        public abstract event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Caption { get; set; } = "?";
        public string Tooltip { get; set; } = "";
        public string Context { get; set; } = "";

        public virtual bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        /// <summary>
        /// Returns wherever this command should be shown/can be used at all or not.
        /// </summary>
        /// <param name="parameter">Some object in the command's context</param>
        /// <returns></returns>
        public virtual bool CanHandle(object parameter)
        {
            return CanExecute(parameter);
        }

        public virtual void Execute(object parameter)
        {
        }
    }

    public abstract class IAddonCommand<T> : IAddonCommand
    {
        public virtual bool CanExecute(T parameter)
        {
            return base.CanExecute(parameter);
        }

        public virtual bool CanHandle(T parameter)
        {
            return base.CanHandle(parameter);
        }

        public virtual void Execute(T parameter)
        {
            base.Execute(parameter);
        }
    }
}

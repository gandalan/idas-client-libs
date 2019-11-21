using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Vorgaenge
{
    public interface IBelegItemCommand : ICommand
    {
        void CanExecute(IBelegAuswahlItem parameter);
        void Execute(IBelegAuswahlItem parameter);
        string Caption { get; }
        string Tooltip { get; }
    }
}

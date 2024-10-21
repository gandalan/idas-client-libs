using System.Windows.Input;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Lager;

public interface ILagerVerwaltungOeffnenCommand : ICommand
{
    bool Visible { get; }
}

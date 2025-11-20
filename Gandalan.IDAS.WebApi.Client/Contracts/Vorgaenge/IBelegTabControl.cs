using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge;

namespace Gandalan.IDAS.Client.Contracts.Vorgaenge;

public interface IBelegTabControl
{
    string TabCaption { get; }
    int Order { get; }

    bool ShowOnlyInDevMode { get; }

    Task OnSave();

    Task OnNavigation(TabNavigationKind kind);
}

using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Vorgaenge;

public interface IBelegTabControl
{
    string TabCaption { get; }
    int Order { get; }

    bool ShowOnlyInDevMode { get; }

    Task OnSave();

    Task OnNavigation(TabNavigationKind kind);
}
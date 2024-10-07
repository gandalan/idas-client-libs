using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Vorgaenge;

public interface IBelegPositionTabControl
{
    string TabCaption { get; }
    int Order { get; }

    bool ShowOnlyInDevMode { get; }

    Task OnSave();

    Task OnNavigation(TabNavigationKind kind);
}

public enum TabNavigationKind
{
    Unknown = 0,
    Enter = 1,
    Leave = 2,
}

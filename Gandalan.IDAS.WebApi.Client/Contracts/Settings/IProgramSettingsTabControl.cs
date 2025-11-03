using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Settings;

public interface IProgramSettingsTabControl
{
    string TabCaption { get; }

    uint Order { get; }

    object DataContext { get; set; }

    bool ShowOnlyInDevMode { get; }

    Task OnSave();
    Task OnNavigation(TabNavigationKind kind);
}

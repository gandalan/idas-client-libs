using System.Collections.ObjectModel;

namespace Gandalan.Client.Contracts.Navigation;

public interface INavigationSubGroup
{
    string Caption { get; set; }
    int Order { get; set; }
    ObservableCollection<INavigationItem> Items { get; set; }
    bool IsVisible { get; set; }
}

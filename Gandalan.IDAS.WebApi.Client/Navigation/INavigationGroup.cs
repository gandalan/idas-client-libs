using System.Collections.ObjectModel;

namespace Gandalan.Client.Contracts.Navigation
{
    public interface INavigationGroup
    {
        string Caption { get; set; }
        ObservableCollection<INavigationItem> Items { get; set; }
        int Order { get; set; }
    }
}

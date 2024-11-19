using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gandalan.Client.Contracts.Navigation;

namespace Gandalan.Client.Contracts.UIServices;

public interface INavigationManager
{
    Task AddNavigationItem(INavigationItem data);
    ObservableCollection<INavigationGroup> GetNavigationGroups();
    event EventHandler NavigationItemsChanged;

    void SetGroupOrder(string groupName, int order);

    void SetGroupIcon(string groupName, object icon);
    void SetSubGroupOrder(string groupName, string subGroupName, int order);
}

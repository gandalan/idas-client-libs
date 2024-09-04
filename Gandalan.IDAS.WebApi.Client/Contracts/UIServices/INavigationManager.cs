using System;
using System.Collections.ObjectModel;
using Gandalan.Client.Contracts.Navigation;

namespace Gandalan.Client.Contracts.UIServices;

public interface INavigationManager
{
    void AddNavigationItem(INavigationItem data);
    ObservableCollection<INavigationGroup> GetNavigationGroups();
    event EventHandler NavigationItemsChanged;

    void SetGroupOrder(string groupName, int order);

    void SetGroupIcon(string groupName, object icon);
}

using Gandalan.Client.Contracts.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface INavigationManager
    {
        void AddNavigationItem(INavigationItem data);
        ObservableCollection<INavigationGroup> GetNavigationGroups();
        event EventHandler NavigationItemsChanged;

        void SetGroupOrder(string groupName, int order);
    }
}

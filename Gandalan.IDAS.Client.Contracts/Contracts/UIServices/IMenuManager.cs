using Gandalan.Plugins.Common.Contracts;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IMenuManager
    {
        void AddNavigationItem(INavigationItem data);
        List<INavigationGroup> GetNavigationGroups();
        event EventHandler NavigationItemsChanged;

        void SetGroupOrder(string groupName, int order);
    }
}

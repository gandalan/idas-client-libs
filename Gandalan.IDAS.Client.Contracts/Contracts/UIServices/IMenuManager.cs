using Gandalan.Plugins.Common.Contracts;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IMenuManager
    {
        void AddMenuItem(INavigationItem data);
        List<INavigationGroup> GetMenuItems();
        event EventHandler MenuItemsChanged;

        void SetGroupOrder(string groupName, int order);
    }
}

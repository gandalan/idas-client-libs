using Gandalan.Plugins.Common.Contracts;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IMenuManager
    {
        void AddMenuItem(IMenuItem data);
        List<IMenuGroup> GetMenuItems();
        event EventHandler MenuItemsChanged;

        void SetGroupOrder(string groupName, int order);
    }
}

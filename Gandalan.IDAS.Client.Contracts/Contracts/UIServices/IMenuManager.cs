using Gandalan.Plugins.Common.Contracts;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IMenuManager
    {
        void AddMenuItem(IMenuItem data);
        IList<IMenuItem> GetMenuItems(IMenuGroup group);
        IList<IMenuGroup> GetMenuGroups();
        event EventHandler MenuItemsChanged;

        void SetGroupOrder(string groupName, int order);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.Client.Contracts.Navigation;

namespace Gandalan.Client.Contracts.UIServices;

public interface INavigationManager
{
    Task AddNavigationItem(INavigationItem data);
    Task RemoveNavigationItem(INavigationItem itemToRemove);
    Task RemoveNavigationItem(Func<IList<INavigationItem>, INavigationItem> itemToRemove);
    Task RemoveNavigationItems(Func<IList<INavigationItem>, IEnumerable<INavigationItem>> itemsToRemove);

    Task SetGroupOrder(string groupName, int order);
    Task SetGroupIcon(string groupName, object icon);
    Task SetSubGroupOrder(string groupName, string subGroupName, int order);
}

using Gandalan.Plugins.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface INavigationManager
    {
        void AddNavigationItem(INavigationItem data);
        List<INavigationGroup> GetNavigationGroups();
        event EventHandler NavigationItemsChanged;

        void SetGroupOrder(string groupName, int order);
    }
}

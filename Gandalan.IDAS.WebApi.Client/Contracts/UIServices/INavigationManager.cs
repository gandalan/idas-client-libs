using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gandalan.Client.Contracts.Navigation;

namespace Gandalan.Client.Contracts.UIServices;

public interface INavigationManager
{
    Task AddNavigationItem(INavigationItem data);
    Task SetGroupOrder(string groupName, int order);
    Task SetGroupIcon(string groupName, object icon);
    Task SetSubGroupOrder(string groupName, string subGroupName, int order);
}

using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IUINavigator
    {
        void SetContainerControl(object control);
        void NavigateTo(object control, bool clearHistory = false, Func<Task> onShown = null);
        void NavigateBack();

        string CurrentCaption { get; }
        bool NavigationAllowed { get; }
        
        event EventHandler NavigationOccurred;
    }
}

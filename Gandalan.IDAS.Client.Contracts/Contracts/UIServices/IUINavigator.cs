using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IUINavigator
    {
        void SetContainerControl(object control);
        void NavigateTo(object control, bool clearHistory = false, Func<Task> onShown = null);
        void NavigateTo<T>(bool clearHistory = false, Func<T, IInteractivePanel, Task> onShown = null) where T : class;
        void NavigateBack();

        string CurrentCaption { get; }
        bool NavigationAllowed { get; }
        
        event EventHandler NavigationOccurred;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IUINavigator
    {
        void SetContainerControl(Panel control);
        void NavigateTo(UserControl control, bool clearHistory = false, Func<Task> onShown = null);
        void NavigateBack();

        string CurrentCaption { get; }
        bool NavigationAllowed { get; }
        
        event EventHandler NavigationOccurred;
    }
}

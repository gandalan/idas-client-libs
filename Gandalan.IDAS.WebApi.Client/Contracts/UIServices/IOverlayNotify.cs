using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IOverlayNotify
    {
        void ShowOverlay(string message, UserNotifyMessageType type, object control);
        void ShowOverlay(object uiElement, UserNotifyMessageType type, object control);
        void HideOverlay(object control);
        void ToogleOverlay(object control);
        void OpenOverlay(object control);
    }
}

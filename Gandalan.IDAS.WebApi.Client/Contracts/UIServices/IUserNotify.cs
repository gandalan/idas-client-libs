using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IUserNotify
    {
        bool Active { get; set; }
        UserNotifyMessageType MessageType { get; }

        void ShowException(Exception ex);
        void ShowMessage(string message, UserNotifyMessageType type);
        void ClearMessage();

        event EventHandler NotificationChanged;
    }
}

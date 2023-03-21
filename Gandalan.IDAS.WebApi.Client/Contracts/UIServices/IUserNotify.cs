using System;

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

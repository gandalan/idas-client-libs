using System;

namespace Gandalan.Client.Contracts.UIServices;

public interface IUserNotify
{
    bool Active { get; set; }
    bool StickyActive { get; set; }
    UserNotifyMessageType MessageType { get; }

    void ShowException(Exception ex);
    void ShowMessage(string message, UserNotifyMessageType type, bool sticky = false);
    void ShowMessage(string message, UserNotifyMessageType type, TimeSpan displayDuration, bool sticky = false);
    void ClearMessage();

    event EventHandler NotificationChanged;
}

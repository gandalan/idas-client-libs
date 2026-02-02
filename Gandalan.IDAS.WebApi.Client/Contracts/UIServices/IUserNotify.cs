using System;

namespace Gandalan.Client.Contracts.UIServices;

public interface IUserNotify
{
    bool Active { get; set; }
    bool StickyActive { get; set; }
    UserNotifyMessageType MessageType { get; }

    void ShowException(Exception ex);
    void ShowMessage(string message, UserNotifyMessageType type, bool sticky = false, TimeSpan? timerInterval = null);
    void ClearMessage();

    event EventHandler NotificationChanged;
}

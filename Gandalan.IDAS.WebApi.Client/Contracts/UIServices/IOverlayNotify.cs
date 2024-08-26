namespace Gandalan.Client.Contracts.UIServices;

public interface IOverlayNotify
{
    void ShowOverlay(string message, UserNotifyMessageType type, object control);
    void ShowOverlay(object uiElement, UserNotifyMessageType type, object control);
    void HideOverlay(object control);
    void ToggleOverlay(object control);
    void OpenOverlay(object control);
    void CloseOverlay(object control);
}
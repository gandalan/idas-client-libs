namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices;

/// <summary>
/// Service for collection end user feedback, for instance via the
/// "smiley" button in the top right corner of an app
/// </summary>
public interface IFeedbackService
{
    /// <summary>
    /// i.e. opens a dialog window, takes screenshots, emails them etc.
    /// </summary>
    void CollectUserFeedback();
}
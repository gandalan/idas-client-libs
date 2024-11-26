using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.UIServices;

/// <summary>
/// UI-Service for collecting end user feedback.
/// </summary>
public interface IFeedbackService
{
    /// <summary>
    /// opens the feedback dialog window to create a new feedback entry.
    /// </summary>
    Task OpenNewFeedbackWindow();

    /// <summary>
    /// navigate to a WebView to create a new feedback entry.
    /// </summary>
    /// <param name="pcode">optional, preselected pcode</param>
    /// <returns></returns>
    Task NavigateToNewFeedback(string pcode = null);

    /// <summary>
    /// navigate to a WebView to view the feedback entry list.
    /// </summary>
    Task NavigateToFeedbackList();
}

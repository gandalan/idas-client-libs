using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices;

public interface IProgressNotify
{
    /// <summary>
    /// Show a progress indicator for an indeterminate Task (i.e. no
    /// percentage for progress)
    /// </summary>
    /// <param name="title">Title to show</param>
    /// <param name="toExecute">Function to run</param>
    /// <param name="extraWaitTimeMs">Additional time the dialog stays open after <paramref name="toExecute"/> has finished executing. Time in milliseconds</param>
    Task ShowProgress(string title, Func<Task> toExecute, int extraWaitTimeMs = 0);

    /// <summary>
    /// Show a progress indicator for a Task that updates progress
    /// </summary>
    /// <param name="title">Title to show</param>
    /// <param name="toExecute">Function to run, IProgressNotify is passed as param for updating</param>
    /// <param name="extraWaitTimeMs">Additional time the dialog stays open after <paramref name="toExecute"/> has finished executing. Time in milliseconds</param>
    Task ShowProgress(string title, Func<IProgressNotify, Task> toExecute, int extraWaitTimeMs = 0);

    /// <summary>
    /// Function to display the progress value for determinate progress tasks
    /// </summary>
    /// <param name="percent">value</param>
    Task UpdateProgress(int percent);

    /// <summary>
    /// Function to display the progress value for determinate progress tasks
    /// </summary>
    /// <param name="percent">value</param>
    /// <param name="text"></param>
    Task UpdateProgress(int percent, string text);

    /// <summary>
    /// Function to display the progress value for determinate progress tasks
    /// </summary>
    /// <param name="text">value</param>
    Task UpdateProgress(string text);
}

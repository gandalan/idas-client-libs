using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IProgressNotify
    {
        /// <summary>
        /// Show a progress indicator for an indeterminate Task (i.e. no 
        /// percentage for progress)
        /// </summary>
        /// <param name="title">Title to show</param>
        /// <param name="toExecute">Function to run</param>
        /// <returns></returns>
        Task ShowProgress(string title, Func<Task> toExecute);
        /// <summary>
        /// Show a progress indicator for a Task that updates progress
        /// </summary>
        /// <param name="title">Title to show</param>
        /// <param name="toExecute">Function to run, IProgressNotify is passed as param for updating</param>
        /// <returns></returns>
        Task ShowProgress(string title, Func<IProgressNotify, Task> toExecute);
        /// <summary>
        /// Function to display the progress value for determinate progress tasks
        /// </summary>
        /// <param name="percent">value</param>
        /// <returns></returns>
        Task UpdateProgress(int percent);
        /// <summary>
        /// Function to display the progress value for determinate progress tasks
        /// </summary>
        /// <param name="percent">value</param>
        /// <param name="text"></param>
        /// <returns></returns>
        Task UpdateProgress(int percent, string text);
        /// <summary>
        /// Function to display the progress value for determinate progress tasks
        /// </summary>
        /// <param name="text">value</param>
        /// <returns></returns>
        Task UpdateProgress(string text);
    }
}

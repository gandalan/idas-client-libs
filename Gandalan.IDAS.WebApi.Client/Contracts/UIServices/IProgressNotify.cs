using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IProgressNotify
    {
        Task ShowProgress(string title, bool showPercentage, Func<Task> toExecute);
        Task ShowProgress(string title, bool showPercentage, Func<IProgressNotify, Task> toExecute);
        Task UpdateProgress(int percent);
    }
}

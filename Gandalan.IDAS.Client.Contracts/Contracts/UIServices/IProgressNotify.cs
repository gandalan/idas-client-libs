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
        void ShowProgress(string title, bool showPercentage, Func<Task> toExecute);
        void UpdateProgress(int percent);
    }
}

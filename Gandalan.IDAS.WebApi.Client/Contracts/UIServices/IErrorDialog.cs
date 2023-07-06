using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IErrorDialog
    {
        bool ShowError(string title = null, string message = null, Exception exception = null);
    }
}

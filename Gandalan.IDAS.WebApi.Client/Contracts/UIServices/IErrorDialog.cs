using System;

namespace Gandalan.Client.Contracts.UIServices;

public interface IErrorDialog
{
    bool ShowError(string title = null, string message = null, Exception exception = null, bool isFatal = false);
}

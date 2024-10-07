using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts;

public interface IHistorieHelper
{
    Task ProgressInfoAsync(Func<Task> asyncFunc);
    Task ProgressInfoAsync(string label, Func<Task> asyncFunc);
    Task ProgressInfoAsyncFnF(Func<Task> asyncFunc);
    Task ProgressInfoAsyncFnF(string label, Func<Task> asyncFunc);
    Task ProgressInfo(Action action);
    Task ProgressInfo(string label, Action action);
    Task Info(string text);
    Task Warning(string text);
    Task Error(string text);
    Task Fatal(string text);
    Task Fatal(Exception e, string text);
    Task Exception(Exception e);
}

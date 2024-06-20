using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts;

public interface IHistorieHelper
{
    Task ProgressInfoAsync(Func<Task> asyncFunc);
    Task ProgressInfoAsync(string label, Func<Task> asyncFunc);
    void ProgressInfoAsyncFnF(Func<Task> asyncFunc);
    void ProgressInfoAsyncFnF(string label, Func<Task> asyncFunc);
    void ProgressInfo(Action action);
    void ProgressInfo(string label, Action action);
    void Info(string text);
    void Warning(string text);
    void Error(string text);
    void Fatal(string text);
    void Exception(Exception e);
}

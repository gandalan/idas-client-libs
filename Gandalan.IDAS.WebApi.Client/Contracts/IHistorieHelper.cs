using System;

namespace Gandalan.IDAS.WebApi.Client.Contracts
{
    public interface IHistorieHelper
    {
        void ProgressInfo(Action action);
        void ProgressInfo(string label, Action action);
        void Info(string text);
        void Warning(string text);
        void Error(string text);
        void Fatal(string text);
        void Exception(Exception e);
    }
}
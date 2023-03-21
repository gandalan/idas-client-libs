using System;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IReportDisplayList
    {
        void DisplayReportAuswahl();
        bool CanHandle(Type type);
    }
}

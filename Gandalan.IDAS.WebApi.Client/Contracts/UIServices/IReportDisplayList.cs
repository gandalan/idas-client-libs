using System;

namespace Gandalan.Client.Contracts.UIServices
{
    [Obsolete]
    public interface IReportDisplayList
    {
        void DisplayReportAuswahl();
        bool CanHandle(Type type);
    }
}

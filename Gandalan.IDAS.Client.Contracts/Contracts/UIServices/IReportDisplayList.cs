using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IReportDisplayList
    {
        void DisplayReportAuswahl();
        bool CanHandle(Type type);
    }

    public class ReportDisplayListImplDefault : IReportDisplayList
    {
        private readonly IUserNotify _notify;

        public ReportDisplayListImplDefault(IUserNotify notify)
        {
            _notify = notify;
        }

        public void DisplayReportAuswahl()
        {
            _notify.ShowMessage("Report Übersicht kann nicht angezeigt werden.", UserNotifyMessageType.Error);
        }
        public bool CanHandle(Type type)
        {
            return false;
        }
    }
}

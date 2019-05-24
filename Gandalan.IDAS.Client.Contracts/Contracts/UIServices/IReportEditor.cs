using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IReportEditor
    {
        void EditReport(Guid guid);
        void NewReport(ReportDatenTypDTO reportType);
        void CloneReport(Guid guid);
        bool canHandle(Type type);
    }

    public class ReportEditorImplDefault : IReportEditor
    {
        private readonly IUserNotify _notify;

        public ReportEditorImplDefault(IUserNotify notify)
        {
            _notify = notify;
        }

        public void EditReport(Guid guid)
        {
            _notify.ShowMessage("Report Übersicht kann nicht angezeigt werden.", UserNotifyMessageType.Error);
        }

        public void NewReport(ReportDatenTypDTO reportType)
        {
            _notify.ShowMessage("Report kann nicht erstellt werden.", UserNotifyMessageType.Error);
        }

        public void CloneReport(Guid guid)
        {
            _notify.ShowMessage("Report kann nicht geclont werden.", UserNotifyMessageType.Error);
        }
        public bool canHandle(Type type)
        {
            return false;
        }
    }
}

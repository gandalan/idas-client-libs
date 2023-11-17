using System;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Contracts.UIServices
{
    [Obsolete]
    public interface IReportEditor
    {
        void EditReport(Guid guid);
        void NewReport(ReportDatenTypDTO reportType);
        void CloneReport(Guid guid);
        bool canHandle(Type type);
    }
}

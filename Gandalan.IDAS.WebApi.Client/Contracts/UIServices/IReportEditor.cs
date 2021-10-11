using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IReportEditor
    {
        void EditReport(Guid guid);
        void NewReport(ReportDatenTypDTO reportType);
        void CloneReport(Guid guid);
        bool canHandle(Type type);
    }
}

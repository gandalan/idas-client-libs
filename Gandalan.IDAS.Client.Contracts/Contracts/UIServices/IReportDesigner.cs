using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IReportDesigner
    {
        void EditReport(ReportDTO report, string sampleData);
        bool canHandle(Type type);
    }
}

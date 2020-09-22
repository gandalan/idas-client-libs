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
        ReportTypeDTO ReportType { get; set; }
    }

    public interface IReportDesinger<T> : IReportDesigner where T : class
    {
        void EditReport(ReportDTO report, object sampleData);
    }
}

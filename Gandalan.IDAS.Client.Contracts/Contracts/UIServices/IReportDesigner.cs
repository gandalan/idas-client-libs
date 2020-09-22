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
    }

    public interface IReportDesinger<T> : IReportDesigner where T : class
    {
        void EditReport(ReportDTO report, object sampleData);
        ReportTypeDTO ReportType { get; set; }
    }
}

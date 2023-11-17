using System;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Contracts.UIServices
{
    [Obsolete]
    public interface IReportDesigner
    {
        ReportTypeDTO ReportType { get; set; }
    }

    [Obsolete]
    public interface IReportDesigner<T> : IReportDesigner where T : class
    {
        void EditReport(ReportDTO report, object sampleData);
    }
}

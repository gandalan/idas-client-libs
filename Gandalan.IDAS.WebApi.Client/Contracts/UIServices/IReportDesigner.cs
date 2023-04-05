using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IReportDesigner
    {
        ReportTypeDTO ReportType { get; set; }
    }

    public interface IReportDesigner<T> : IReportDesigner where T : class
    {
        void EditReport(ReportDTO report, object sampleData);
    }
}

using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report
{
    public interface IReport
    {
        string Name { get; set; }
        ReportTypeDTO ReportType { get; set; }
        ReportAction[] AllowedActions { get; }

        bool CanHandle(object data = null);
        Task Execute(ReportAction action, string printerName = null, string fileName = null, int copies = 1);
    }

    public interface IReport<T> : IReport where T : class
    {
        T Data { get; set; }
        Task Initialize(T data);
    }

    public enum ReportAction
    {
        Cancel = 0,
        Print = 1,
        Preview = 3,
        Export = 4,
        Design = 99
    }
}

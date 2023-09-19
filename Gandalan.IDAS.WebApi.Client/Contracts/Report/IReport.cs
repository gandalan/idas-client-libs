using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Contracts.Report;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report
{
    public interface IReport
    {
        string Name { get; set; }
        ReportTypeDTO ReportType { get; set; }
        ReportAction[] AllowedActions { get; }
        ReportCapability[] Capabilities { get; }

        bool CanHandle(object data = null);
        [Obsolete("Use Execute(ReportExecuteSettings) instead")]
        Task Execute(ReportAction action, string printerName = null, string fileName = null, int copies = 1);
        Task Execute(ReportExecuteSettings reportSettings);
    }

    public interface IReport<T> : IReport where T : class
    {
        T Data { get; set; }
        Task Initialize(T data);
    }

    public interface IHTMLReport<T> : IReport<T> where T : class
    {
        string WorkingDir { get; set; }
        bool UseReportRepository { get; set; }
    }

    public enum ReportAction
    {
        Cancel = 0,
        Print = 1,
        Preview = 3,
        Export = 4,
        Design = 99
    }

    public enum ReportCapability
    {
        Watermark = 1,
    }

    public class ReportExecuteSettings
    {
        public ReportAction ReportAction { get; set; }
        public string PrinterName { get; set; } = null;
        public string FileName { get; set; } = null;
        public int Copies { get; set; } = 1;
        public string Watermark { get; set; } = null;

        public static ReportExecuteSettings FromReportAuswahlResult(IReportAuswahlResult result)
        {
            return new ReportExecuteSettings
            {
                ReportAction = result.Action,
                PrinterName = result.PrinterName,
                FileName = result.FileName,
                Copies = result.Copies,
                Watermark = result.Watermark
            };
        }
    }
}

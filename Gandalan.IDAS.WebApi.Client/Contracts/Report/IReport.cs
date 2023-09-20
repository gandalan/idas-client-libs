using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Contracts.Report;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report
{
    public abstract class IReport
    {
        protected string WorkingDir { get; set; }
        protected string DataDir { get; set; }
        //private bool UseReportRepository { get; set; }

        public string Name { get; set; }
        public ReportTypeDTO ReportType { get; set; }
        public ReportAction[] AllowedActions { get; }
        public ReportCapability[] Capabilities { get; }

        public abstract bool CanHandle(object data = null);

        [Obsolete("Use Execute(ReportExecuteSettings) instead")]
        public Task Execute(ReportAction action, string printerName = null, string fileName = null, int copies = 1)
            => Execute(new ReportExecuteSettings() { ReportAction = action, PrinterName = printerName, FileName = fileName, Copies = copies });

        public abstract Task Execute(ReportExecuteSettings reportSettings);

        public async virtual Task InitializeFolders(ReportAction action, bool copyCommomHtmlData = true)
        {
            // TODO: Setup folders
        }
    }

    public abstract class IReport<T> : IReport where T : class
    {
        public T Data { get; set; }
        public abstract Task Initialize(T data);
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

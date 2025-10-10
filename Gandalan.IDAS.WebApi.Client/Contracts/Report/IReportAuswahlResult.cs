using Gandalan.IDAS.Client.Contracts.Contracts.Report;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Report;

public interface IReportAuswahlResult
{
    IReport Report { get; set; }
    ReportAction Action { get; set; }
    string PrinterName { get; set; }
    string FileName { get; set; }
    int Copies { get; set; }
    string Watermark { get; set; }
    bool ShowSerienName { get; set; }
}

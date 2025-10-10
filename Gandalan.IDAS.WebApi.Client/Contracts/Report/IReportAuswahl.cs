using System.Collections.Generic;
using Gandalan.IDAS.Client.Contracts.Contracts.Report;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Report;

public interface IReportAuswahl
{
    IReportAuswahlResult Auswaehlen(IEnumerable<IReport> reports, string printerName = null, bool forceDialog = false,
        bool selectDialogOnly = false, bool supressPrinterSelection = false, bool ignoreFileDialogOnExport = false,
        string defaultPdfReportFileName = null, string fileNamePrefix = null);
}

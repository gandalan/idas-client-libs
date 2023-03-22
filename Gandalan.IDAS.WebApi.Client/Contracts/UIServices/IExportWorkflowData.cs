using System;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IExportWorkflowData
    {
        Guid ReportGuid { get; set; }
        object Daten { get; set; }
        string FileFormat { get; set; }
        string FilePath { get; set; }
    }
    public class ExportWorkflowData : IExportWorkflowData
    {
        public Guid ReportGuid { get; set; }
        public object Daten { get; set; }
        public string FileFormat { get; set; }
        public string FilePath { get; set; }

        public ExportWorkflowData(Object daten, Guid reportGuid)
        {
            Daten = daten;
            ReportGuid = reportGuid;
        }
    }
}

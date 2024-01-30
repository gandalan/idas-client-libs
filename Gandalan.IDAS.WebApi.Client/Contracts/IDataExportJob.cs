using System;
using Gandalan.IDAS.Jobs.Contracts;

namespace Gandalan.IDAS.WebApi.Data.Contracts
{
    public interface IDataExportJob : IBackgroundJob<IDataExportJobData>
    {
    }

    public interface IDataExportJobData : IJobData
    {
        Guid ExportGuid { get; set; }
        object Data { get; set; }
        Guid ReportGuid { get; set; }
        string ExportPath { get; set; }
        string FileFormat { get; set; }
        string ResultAsBase64String { get; set; }
    }

    public class DataExportJobData : IDataExportJobData
    {
        public Guid ExportGuid { get; set; } = Guid.NewGuid();
        public object Data { get; set; }
        public Guid ReportGuid { get; set; }
        public string ExportPath { get; set; }
        public string FileFormat { get; set; }
        public string ResultAsBase64String { get; set; }
        public bool ReportsProgress { get; set; }
        public int ProgressPercent { get; set; }
        public bool HasFinished { get; set; }

        public DataExportJobData(object daten, Guid reportGuid)
        {
            Data = daten;
            ReportGuid = reportGuid;
        }
    }
}

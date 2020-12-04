using Gandalan.IDAS.Jobs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.Contracts
{
    public interface IDataExportJob : IBackgroundJob<IDataExportJobData>
    {
    }

    public interface IDataExportJobData : IJobData
    {
        Guid PrintGuid { get; set; }
        Object Data { get; set; }
        Guid ReportGuid { get; set; }
        string FileFormat { get; set; }
        string ResultAsBase64String { get; set; }
    }

    public class DataExportJobData : IDataExportJobData
    {
        public Guid PrintGuid { get; set; } = Guid.NewGuid();
        public object Data { get; set; }
        public Guid ReportGuid { get; set; }
        public string FileFormat { get; set; }
        public string ResultAsBase64String { get; set; }
        public bool ReportsProgress { get; set; }
        public int ProgressPercent { get; set; }
        public bool HasFinished { get; set; }

        public DataExportJobData(Object daten, Guid reportGuid)
        {
            Data = daten;
            ReportGuid = reportGuid;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IExportWorkflowData
    {
        Guid ReportGuid { get; set; }
        object Daten { get; set; }
        string FileFormat { get; set; }
    }
    public class ExportWorkflowData : IExportWorkflowData
    {
        public Guid ReportGuid { get; set; }
        public object Daten { get; set; }
        public string FileFormat { get; set; }

        public ExportWorkflowData(Object daten, Guid reportGuid)
        {
            Daten = daten;
            ReportGuid = reportGuid;
        }
    }
}

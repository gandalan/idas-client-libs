using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IPrintWorkflowData
    {
        ReportDatenTypDTO ReportTyp { get; set; }
        string JsonDaten { get; set; }
        bool PrintSelectedData { get; set; }
        bool ShowPrintSelectedData { get; set; }
        Func<IPrintWorkflowData, Task<string>> ActionToExecute{ get; set; }
    }

    public class PrintWorkflowData : IPrintWorkflowData
    {
        public ReportDatenTypDTO ReportTyp { get; set; }
        public string JsonDaten { get; set; }
        public bool PrintSelectedData { get; set; }
        public bool ShowPrintSelectedData { get; set; } = true;
        public Func<IPrintWorkflowData, Task<string>> ActionToExecute { get; set; }
    }
}

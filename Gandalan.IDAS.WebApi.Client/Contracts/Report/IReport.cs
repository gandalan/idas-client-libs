using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report
{
    public interface IReport
    {
        string Name { get; }
        ReportTypeDTO ReportType { get; set; }
        ReportAction[] AllowedActions { get; }

        Task Execute(ReportAction action, params object[] additonalParams);
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
        PrintWithDialog = 2,
        Preview = 3,
        Export = 4,
        Design = 99
    }
}

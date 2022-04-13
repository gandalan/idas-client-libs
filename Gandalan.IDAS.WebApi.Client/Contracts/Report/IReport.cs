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
        Task Preview();
        Task Print(bool showPrinterDialog = true, string printerName = null);
        Task Export(string fileName, string exportFormat);
        void Design();
    }

    public interface IReport<T> : IReport where T : class
    {
        T Data { get; set; }
        Task Initialize(T data);
    }
}

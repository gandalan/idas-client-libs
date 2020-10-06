using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ReportSampleDatasWebRoutinen : WebRoutinenBase
    {
        public ReportSampleDatasWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ReportSampleDataDTO[] GetAllSampleData()
        {
            if (Login())
            {
                return Get<ReportSampleDataDTO[]>("ReportSampleData");
            }
            return null;
        }

        public ReportSampleDataDTO GetReportSampleData(Guid id)
        {
            if (Login())
            {
                return Get<ReportSampleDataDTO>("ReportSampleData?id=" + id.ToString());
            }
            return null;
        }

        public string SaveReportSampleData(ReportSampleDataDTO dto)
        {
            if (Login())
            {
                return Put("ReportSampleData", dto);
            }
            return null;
        }

        public void DeleteReportSampleData(Guid reportDataSourceGuid)
        {
            if (Login())
            {
                Delete("ReportSampleData/" + reportDataSourceGuid);
            }
        }


        public async Task<ReportSampleDataDTO[]> GetAllSampleDataAsync()
        {
            return await Task.Run(() => GetAllSampleData());
        }
        public async Task<ReportSampleDataDTO> GetReportSampleDataAsync(Guid id)
        {
            return await Task.Run(() => GetReportSampleData(id));
        }
        public async Task SaveReportSampleDataAsync(ReportSampleDataDTO dto)
        {
            await Task.Run(() => SaveReportSampleData(dto));
        }
        public async Task DeleteReportSampleDataAsync(Guid reportGuid)
        {
            await Task.Run(() => DeleteReportSampleData(reportGuid));
        }
    }
}

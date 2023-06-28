using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ReportSampleDatasWebRoutinen : WebRoutinenBase
    {
        public ReportSampleDatasWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<ReportSampleDataDTO[]> GetAllSampleDataAsync() 
            => await GetAsync<ReportSampleDataDTO[]>("ReportSampleData");

        public async Task<ReportSampleDataDTO> GetReportSampleDataAsync(Guid id)
            => await GetAsync<ReportSampleDataDTO>($"ReportSampleData?id={id}");

        public async Task SaveReportSampleDataAsync(ReportSampleDataDTO dto)
            => await PutAsync("ReportSampleData", dto);

        public async Task DeleteReportSampleDataAsync(Guid reportGuid)
            => await DeleteAsync($"ReportSampleData/{reportGuid}");
    }
}

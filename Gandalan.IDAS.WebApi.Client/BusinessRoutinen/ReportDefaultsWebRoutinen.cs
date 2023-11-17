using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    [Obsolete]
    public class ReportDefaultsWebRoutinen : WebRoutinenBase
    {
        public ReportDefaultsWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<ReportDTO[]> GetAllAsync() 
            => await GetAsync<ReportDTO[]>("ReportDefaults");

        public async Task<ReportDTO> GetReportDefaultAsync(Guid id)
            => await GetAsync<ReportDTO>("ReportDefaults?id=" + id.ToString());

        public async Task SaveReportDefaultAsync(ReportDTO dto) 
            => await PutAsync("ReportDefaults/" + dto.ReportGuid, dto);

        public async Task DeleteReportDefaultAsync(Guid reportGuid) 
            => await DeleteAsync("ReportDefaults/" + reportGuid);
    }
}

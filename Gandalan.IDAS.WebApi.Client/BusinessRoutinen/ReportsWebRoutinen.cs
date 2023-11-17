using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    [Obsolete]
    public class ReportsWebRoutinen : WebRoutinenBase
    {
        public ReportsWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<ReportDTO[]> GetAllAsync() 
            => await GetAsync<ReportDTO[]>("Reports");

        public async Task<ReportDTO[]> GetAllAsync(DateTime changedSince) 
            => await GetAsync<ReportDTO[]>($"Reports/?changedSince={changedSince:o}");

        public async Task<ReportDTO> GetReportAsync(Guid id) 
            => await GetAsync<ReportDTO>($"Reports?id={id}");

        public async Task SaveReportAsync(ReportDTO dto) 
            => await PutAsync($"Reports/{dto.ReportGuid}", dto);

        public async Task DeleteReportAsync(Guid reportGuid)
            => await DeleteAsync($"Reports/{reportGuid}");

        public async Task CopyReportAsync(Guid ZielMandantGuid, List<Guid> reportGuids)
            => await PutAsync($"Reports?ZielMandantGuid={ZielMandantGuid}", reportGuids);

    }
}

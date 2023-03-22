using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IReportService
    {
        Task<ReportDTO[]> GetAllAsync();
        Task<ReportDTO[]> GetAllDefaultAsync();
        Task<ReportSampleDataDTO[]> GetAllReportSampleDatasAsync();
        Task SaveReport(ReportDTO reportToSave);
        Task DeleteReport(ReportDTO reportToDelete);
        Task<ReportDTO> GetReport(Guid guid);
        Task<ReportDTO> GetDefaultReport(Guid guid);
        Task CopyReportZielMandant(Guid ZielMandantGuid, List<Guid> reportGuids);
    }
}

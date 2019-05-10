using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ReportsWebRoutinen : WebRoutinenBase
    {
        public ReportsWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public ReportDTO[] GetAll()
        {
            if (Login())
            {
                return Get<ReportDTO[]>("Reports");
            }
            return null;
        }

        public ReportDTO GetReport(Guid id)
        {
            if (Login())
            {
                try
                {
                    return Get<ReportDTO>("Reports?id=" + id.ToString());
                }
                catch
                {
                    if (!IgnoreOnErrorOccured)
                        throw;
                }
            }
            return null;
        }

        public string SaveReport(ReportDTO dto)
        {
            if (Login())
            {
                return Put("Reports/" + dto.ReportGuid, dto);
            }
            return null;
        }

        public void DeleteReport(Guid reportGuid)
        {
            if (Login())
            {
                Delete("Reports/" + reportGuid);
            }
        }


        public async Task<ReportDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task<ReportDTO> GetReportAsync(Guid id)
        {
            return await Task.Run(() => GetReport(id));
        }
        public async Task SaveReportAsync(ReportDTO dto)
        {
            await Task.Run(() => SaveReport(dto));
        }
        public async Task DeleteReportAsync(Guid reportGuid)
        {
            await Task.Run(() => DeleteReport(reportGuid));
        }
    }
}

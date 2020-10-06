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
    public class ReportDefaultsWebRoutinen : WebRoutinenBase
    {
        public ReportDefaultsWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ReportDTO[] GetAll()
        {
            if (Login())
            {
                return Get<ReportDTO[]>("ReportDefaults");
            }
            return null;
        }

        public ReportDTO GetReportDefault(Guid id)
        {
            if (Login())
            {
                try
                {
                    return Get<ReportDTO>("ReportDefaults?id=" + id.ToString());
                }
                catch
                {
                    if (!IgnoreOnErrorOccured)
                        throw;
                }
            }
            return null;
        }

        public string SaveReportDefault(ReportDTO dto)
        {
            if (Login())
            {
                return Put("ReportDefaults/" + dto.ReportGuid, dto);
            }
            return null;
        }

        public void DeleteReportDefault(Guid reportGuid)
        {
            if (Login())
            {
                Delete("ReportDefaults/" + reportGuid);
            }
        }


        public async Task<ReportDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task<ReportDTO> GetReportDefaultAsync(Guid id)
        {
            return await Task.Run(() => GetReportDefault(id));
        }
        public async Task SaveReportDefaultAsync(ReportDTO dto)
        {
            await Task.Run(() => SaveReportDefault(dto));
        }
        public async Task DeleteReportDefaultAsync(Guid reportGuid)
        {
            await Task.Run(() => DeleteReportDefault(reportGuid));
        }
    }
}

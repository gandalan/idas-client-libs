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
    public class ReportsWebRoutinen : WebRoutinenBase
    {
        public ReportsWebRoutinen(IWebApiConfig settings) : base(settings)
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

        public ReportDTO[] GetAll(DateTime changedSince)
        {
            if (Login())
            {
                return Get<ReportDTO[]>($"Reports/?changedSince={changedSince.ToString("o")}");
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

        public string CopyReport(Guid ZielMandantGuid, List<Guid> reportGuids)
        {
            if (Login())
            {
                return Put("Reports?ZielMandantGuid=" + ZielMandantGuid, reportGuids);
            }
            return null;
        }


        public async Task<ReportDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task<ReportDTO[]> GetAllAsync(DateTime changedSince)
        {
            return await Task.Run(() => GetAll(changedSince));
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
        public async Task CopyReportAsync(Guid ZielMandantGuid, List<Guid> reportGuids)
        {
            await Task.Run(() => CopyReport(ZielMandantGuid, reportGuids));
        }
    }
}

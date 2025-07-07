using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AvReportDataWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<List<AvReportVorgangDto>> GetVorgaengeAsync(AvReportVorgangRequestDto request)
        => await PostAsync<List<AvReportVorgangDto>>("avreportdata/vorgaenge", request);
}

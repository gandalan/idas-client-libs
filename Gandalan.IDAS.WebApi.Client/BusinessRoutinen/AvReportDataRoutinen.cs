using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports;
using Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports.Requests;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AvReportDataWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<List<AvReportAvBelegPositionDto>> GetAvPositionenForSerieAsync(AvReportSerieAvPositionRequestDto request)
        => await PostAsync<List<AvReportAvBelegPositionDto>>("avreportdata/avpositionen/serie", request);

    public async Task<List<AvReportAvBelegPositionDto>> GetAvPositionenForVorgaengeAsync(AvReportVorgangAvPositionenRequestDto request)
        => await PostAsync<List<AvReportAvBelegPositionDto>>("avreportdata/avpositionen/vorgaenge", request);

    public async Task<List<AvReportVorgangDto>> GetVorgaengeAsync(AvReportVorgangRequestDto request)
        => await PostAsync<List<AvReportVorgangDto>>("avreportdata/vorgaenge", request);

    public async Task<List<AvReportBelegDto>> GetBelegeAsync(AvReportBelegRequestDto request)
        => await PostAsync<List<AvReportBelegDto>>("avreportdata/belege", request);

    public async Task<List<AvReportBelegPositionDto>> GetBelegPositionenAsync(AvReportBelegPositionRequestDto request)
        => await PostAsync<List<AvReportBelegPositionDto>>("avreportdata/belegpositionen", request);

    public async Task<List<AvReportBelegPositionDto>> GetFremdfertigungBelegPositionenAsync(AvReportFremdfertigungBelegPositionRequestDto request)
        => await PostAsync<List<AvReportBelegPositionDto>>("avreportdata/fremdfertigungbelegpositionen", request);
}

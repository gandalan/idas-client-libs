using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports.Requests;

public abstract class AvReportAvBelegPositionRequestDto
{
    public bool IncludeMaterial { get; set; }
    public bool IncludeEtiketten { get; set; }
}

public class AvReportSerieAvPositionRequestDto : AvReportAvBelegPositionRequestDto
{
    public static AvReportSerieAvPositionRequestDto ForProduktionslieferschein(Guid serieGuid) => new()
    {
        SerieGuid = serieGuid,
        IncludeMaterial = true,
    };

    public Guid SerieGuid { get; set; }
}

public class AvReportVorgangAvPositionenRequestDto : AvReportAvBelegPositionRequestDto
{
    public static AvReportVorgangAvPositionenRequestDto ForProduktionslieferschein(List<Guid> vorgangGuids) => new()
    {
        VorgangGuids = vorgangGuids,
        IncludeMaterial = true,
    };

    public List<Guid> VorgangGuids { get; set; }

}

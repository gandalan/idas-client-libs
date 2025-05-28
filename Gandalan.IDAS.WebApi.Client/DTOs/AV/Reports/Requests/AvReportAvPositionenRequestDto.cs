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
    public Guid SerieGuid { get; set; }
}

public class AvReportVorgangAvPositionenRequestDto : AvReportAvBelegPositionRequestDto
{
    public List<Guid> VorgangGuids { get; set; }
}

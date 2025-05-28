using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports.Requests;

public class AvReportSerieAvPositionRequestDto
{
    public Guid SerieGuid { get; set; }
}

public class AvReportVorgangAvPositionenRequestDto
{
    public List<Guid> VorgangGuids { get; set; }
}

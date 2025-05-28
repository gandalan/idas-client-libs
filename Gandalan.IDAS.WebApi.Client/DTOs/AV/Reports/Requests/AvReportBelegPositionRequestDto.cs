using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports.Requests;

public record AvReportBelegPositionRequestDto
{
    public List<Guid> BelegPositionenGuids { get; set; }
}

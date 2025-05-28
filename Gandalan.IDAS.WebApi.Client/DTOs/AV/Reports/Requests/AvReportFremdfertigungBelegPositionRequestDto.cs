using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports.Requests;

public record AvReportFremdfertigungBelegPositionRequestDto
{
    public List<Guid> BelegGuidsForFremdfertigung { get; set; }
}

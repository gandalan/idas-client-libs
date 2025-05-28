using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports.Requests;

public record AvReportBelegRequestDto
{
    public List<Guid> BelegGuids { get; set; } = [];
}

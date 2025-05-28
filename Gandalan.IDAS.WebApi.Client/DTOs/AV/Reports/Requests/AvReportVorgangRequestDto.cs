using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports.Requests;

public class AvReportVorgangRequestDto
{
    public List<Guid> VorgangGuids { get; set; } = [];
}

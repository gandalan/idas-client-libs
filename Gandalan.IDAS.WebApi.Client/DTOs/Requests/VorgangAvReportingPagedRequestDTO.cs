using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Requests;

public class VorgangAvReportingPagedRequestDTO
{
    public List<Guid> VorgangGuids { get; set; } = [];
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}

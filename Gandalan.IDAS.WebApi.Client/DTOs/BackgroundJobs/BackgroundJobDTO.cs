using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class BackgroundJobDTO
{
    public Guid BackgroundJobGuid { get; set; }

    public string Kind { get; set; }
    public string Target { get; set; }
    public string TargetUsername { get; set; }
    public string TargetPassword { get; set; }
    public string Payload { get; set; }

    public string ResponseCode { get; set; }
    public string ResponseData { get; set; }

    public bool IsFinished { get; set; }
    public bool HasError { get; set; }
}
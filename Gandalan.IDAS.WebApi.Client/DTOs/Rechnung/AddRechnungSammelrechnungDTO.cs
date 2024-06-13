using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;

public class AddRechnungSammelrechnungDTO
{
    public Guid BelegGuid { get; set; }
    public Guid SammelrechnungGuid { get; set; }
}
using System;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports;

public record AvReportBelegDto
{
    public Guid BelegGuid { get; set; }
    public Guid VorgangGuid { get; set; }

    public string BelegArt { get; set; } = string.Empty;
    public string Terminwunsch { get; set; }
    public BeleganschriftDTO VersandAdresse { get; set; } = new();
    public BeleganschriftDTO BelegAdresse { get; set; } = new();
    public bool VersandAdresseGleichBelegAdresse { get; set; }
    public bool IstSelbstabholer { get; set; }
}

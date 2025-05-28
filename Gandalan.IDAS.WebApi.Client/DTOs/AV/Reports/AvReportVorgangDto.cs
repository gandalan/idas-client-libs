using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports;

public record AvReportVorgangDto
{
    public Guid VorgangGuid { get; set; }
    public long VorgangsNummer { get; set; }
    public string Kommission { get; set; }
    public string Kommission2 { get; set; }
    public AvReportKontaktDto Kunde { get; set; }
}

using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports;

public class AvReportVorgangRequestDto
{
    public List<Guid> VorgangGuids { get; set; } = [];
}

/// <summary>
/// Minimalistic DTO for Vorgang in AV reports.
/// </summary>
public record AvReportVorgangDto
{
    public Guid VorgangGuid { get; set; }
    public long VorgangsNummer { get; set; }
    public string Kommission { get; set; }
    public string Kommission2 { get; set; }
    public List<AvReportBelegDto> Belege { get; set; } = [];
    public AvReportKontaktDto Kunde { get; set; }
}

/// <summary>
/// Minimalistic DTO for Beleg in AV reports.
/// </summary>
public class AvReportBelegDto
{
    public Guid BelegGuid { get; set; }
    public BeleganschriftDTO BelegAdresse { get; set; }
    public BeleganschriftDTO VersandAdresse { get; set; }
    public bool VersandAdresseGleichBelegAdresse { get; set; }
    public string BelegArt { get; set; }
    public string Terminwunsch { get; set; }
    public bool IstSelbstabholer { get; set; }
}

/// <summary>
/// Minimalistic DTO for Kontakt information in AvReportVorgangDto.
/// </summary>
public record AvReportKontaktDto
{
    public string KundenNummer { get; set; }
    public string Land { get; set; }
}

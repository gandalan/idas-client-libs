using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports;

public class AvReportRequestDTO
{
    public List<Guid> VorgangGuids { get; set; } = [];
    public List<Guid> BelegGuids { get; set; } = [];
}

public class AvReportResponseDTO
{
    public List<AvReportVorgangDTO> Vorgaenge { get; set;} = [];
    public List<AvReportBelegDTO> Belege { get; set; } = [];
}

public record AvReportVorgangDTO
{
    public Guid VorgangGuid { get; set; }
    public long VorgangsNummer { get; set; }
    public string Kommission { get; set; }
    public string Kommission2 { get; set; }
    public AvReportKontaktDTO Kunde { get; set; } = new();
}

public record AvReportBelegDTO
{
    public Guid BelegGuid { get; set; }
    public string BelegArt { get; set; } = string.Empty;
    public string Terminwunsch { get; set; }
    public BeleganschriftDTO VersandAdresse { get; set; } = new();
    public BeleganschriftDTO BelegAdresse { get; set; } = new();
    public bool VersandAdresseGleichBelegAdresse { get; set; }
    public bool IstSelbstabholer { get; set; }
}

public record AvReportKontaktDTO
{
    public string KundenNummer { get; set; }
    public string Land { get; set; }
}

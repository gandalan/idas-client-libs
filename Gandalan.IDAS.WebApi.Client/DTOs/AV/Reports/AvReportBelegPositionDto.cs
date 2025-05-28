using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports;

public record AvReportBelegPositionDto
{
    public Guid BelegPositionGuid { get; set; }
    public Guid VorgangGuid { get; set; }
    public Guid BelegGuid { get; set; }

    public int LaufendeNummer { get; set; }
    public string Variante { get; set; }
    public string ArtikelNummer { get; set; }
    public decimal Menge { get; set; }
    public bool IstVE { get; set; }
    public decimal? VEMenge { get; set; }
    public bool IstFremdfertigung { get; set; }
    public List<BelegPositionDatenDTO> Daten { get; set; } = [];
    public string PositionsKommission { get; set; }
    public string Text { get; set; }
    public string Einbauort { get; set; }
    public string SonderwunschText { get; set; }
}

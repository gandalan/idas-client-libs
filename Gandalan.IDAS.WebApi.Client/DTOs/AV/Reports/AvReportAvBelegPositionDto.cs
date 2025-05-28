using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV.Reports;

public record AvReportAvBelegPositionDto
{
    public static implicit operator AvReportAvBelegPositionDto(BelegPositionAVDTO belegPosAvDto) => new()
    {
        BelegPositionAVGuid = belegPosAvDto.BelegPositionAVGuid,
        VorgangGuid = belegPosAvDto.VorgangGuid,
        BelegGuid = belegPosAvDto.BelegGuid,
        BelegPositionGuid = belegPosAvDto.BelegPositionGuid,
        Material = belegPosAvDto.ProduktionsDaten.Material,
        Variante = belegPosAvDto.Variante,
        Pcode = belegPosAvDto.Pcode,
    };

    public Guid BelegPositionAVGuid { get; set; }
    public Guid VorgangGuid { get; set; }
    public Guid BelegGuid { get; set; }
    public Guid BelegPositionGuid { get; set; }

    /// <summary>
    /// From BelegPositionAV.Produktionsdaten.Material
    /// </summary>
    public List<MaterialbedarfDTO> Material { get; set; }
    /// <summary>
    /// From BelegPositionAV.Produktionsdaten.Etiketten
    /// </summary>
    public List<EtikettDTO> Etiketten { get; set; }
    public string Variante { get; set; }
    public string Pcode { get; set; }
}

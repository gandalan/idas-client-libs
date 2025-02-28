using System;

namespace Gandalan.IDAS.WebApi.DTO;

public record CalculationInfoDTO
{
    public long MandantId { get; set; }
    public Guid BelegPositionGuid { get; set; }
    /// <summary>
    /// The timestamp when the calculation was requested.
    /// </summary>
    public DateTime? CalculationRequestTimestamp { get; set; }
    /// <summary>
    /// The timestamp indicating for which request timestamp the calculation was performed.
    /// </summary>
    public DateTime? CalculatedForTimestamp { get; set; }
}

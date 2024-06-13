using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class VorgangHistorienDTO
{
    public List<VorgangHistorieDTO> VorgangHistorien { get; set; }
    public Dictionary<Guid, List<BelegHistorieDTO>> BelegHistorien { get; set; }
    public Dictionary<Guid, List<BelegPositionHistorieDTO>> BelegPositionHistorien { get; set; }
}
using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BelegHistorienDTO
    {
        public List<BelegHistorieDTO> BelegHistorien { get; set; }
        public Dictionary<Guid, List<BelegPositionHistorieDTO>> BelegPositionHistorien { get; set; }
    }
}


using Gandalan.IDAS.WebApi.Data;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface ISerienPositionsItemHelper
    {
        Task<List<PositionSerieItemDTO>> GetSeriePositionItemsFromBeleg(BelegDTO beleg);
        Task<List<PositionSerieItemDTO>> GetSeriePositionItemsFromModus(BelegDTO beleg, List<PositionSerieItemDTO> items, SerieSuchenModus serieSuchenModus);
        Task SaveSeriePositionItemsToSerie(BelegDTO beleg, List<PositionSerieItemDTO> items, bool autoFreigabeErlaubt, bool showDialog = true);
        Task SaveSeriePositionItemsToSerieAuto(BelegDTO beleg, bool autoFreigabeErlaubt);
    }
}

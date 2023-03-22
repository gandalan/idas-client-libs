
using Gandalan.IDAS.WebApi.Data;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface ISerienPositionsItemHelper
    {
        Task<List<PositionSerieItemDTO>> GetSeriePositionItemsFromBeleg(BelegDTO beleg);
        Task<List<PositionSerieItemDTO>> GetSeriePositionItemsFromModus(BelegDTO beleg, List<PositionSerieItemDTO> items, SerieSuchenModus serieSuchenModus);
        Task SaveSeriePositionItemsToSerie(BelegDTO beleg, List<PositionSerieItemDTO> items, bool autoFreigabeErlaubt, bool showDialog = true, bool timerReset = true);
        Task SaveSeriePositionItemsToSerieAuto(BelegDTO beleg, bool autoFreigabeErlaubt, bool timerReset = true);
    }
}

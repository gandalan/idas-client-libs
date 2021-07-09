using Gandalan.IDAS.WebApi.Data.DTOs.AV;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface ISerienManager
    {
        List<SerieDTO> GetSerienByDate(DateTime datum, bool includeStaendigeSerien = false);
        Task<bool> CheckCapacity(SerieDTO serie, BelegDTO belegDto);
        Task<bool> CheckCapacity(SerieDTO serie, BelegPositionDTO belegPositionDto);
        Task<bool> CheckCapacityAV(Guid serieGuid, List<Guid> list);
        Task<SerieDTO> FindNext(BelegDTO beleg, DateTime start);
        Task<SerieDTO> FindNext(BelegPositionDTO belegPosition, DateTime start);

        Task AddToSerie(BelegPositionDTO position, SerieDTO serie);
        Task AddToSerie(IList<BelegPositionAVDTO> position, SerieDTO serie);
        Task RemoveFromSerie(BelegPositionDTO position, SerieDTO serie);
        Task RemoveFromSerie(IList<BelegPositionAVDTO> position, SerieDTO serie);

        Task<List<PositionSerieItemDTO>> GetSeriePositionItemsFromBeleg(BelegDTO beleg);
        Task<List<PositionSerieItemDTO>> GetSeriePositionItemsFromModus(BelegDTO beleg, List<PositionSerieItemDTO> items, SerieSuchenModus serieSuchenModus, bool allePosDisponieren);
        Task SaveSeriePositionItemsToSerie(BelegDTO beleg, List<PositionSerieItemDTO> items, SerieSuchenModus serieSuchenModus, bool showDialog = true);
        Task SaveSeriePositionItemsToSerieAuto(BelegDTO beleg);


    }
}

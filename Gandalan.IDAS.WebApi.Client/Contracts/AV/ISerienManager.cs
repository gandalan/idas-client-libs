using Gandalan.IDAS.WebApi.Data;
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
        Task AddToSerie(BelegPositionDTO position, SerieDTO serie);
        Task AddToSerie(IList<BelegPositionDTO> position, SerieDTO serie);
        Task AddToSerie(BelegPositionAVDTO position, SerieDTO serie);
        Task AddToSerie(IList<BelegPositionAVDTO> positionen, SerieDTO serie);
        Task AddToSerie(Guid avPositionsGuid, SerieDTO serie);
        Task AddToSerie(IList<Guid> avPositionenGuids, SerieDTO serie);


        Task RemoveFromSerie(BelegPositionDTO position, SerieDTO serie);
        Task RemoveFromSerie(IList<BelegPositionDTO> position, SerieDTO serie);
        Task RemoveFromSerie(BelegPositionAVDTO position, SerieDTO serie);
        Task RemoveFromSerie(IList<BelegPositionAVDTO> position, SerieDTO serie);
        Task RemoveFromSerie(Guid avPositionsGuid, SerieDTO serie);
        Task RemoveFromSerie(IList<Guid> avPositionenGuids, SerieDTO serie);
    }
}

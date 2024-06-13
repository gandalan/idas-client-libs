using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV;

public interface ISerienSuche
{
    List<SerieDTO> GetSerienByDate(DateTime datum, bool includeStaendigeSerien = false);
    Task<bool> CheckCapacity(SerieDTO serie, BelegDTO belegDto);
    Task<bool> CheckCapacity(SerieDTO serie, BelegPositionDTO belegPositionDto);
    Task<bool> CheckCapacityAV(Guid serieGuid, List<Guid> list);
    Task<SerieDTO> FindNext(BelegDTO beleg, DateTime start);
    Task<SerieDTO> FindNext(BelegPositionDTO belegPosition, DateTime start);
}
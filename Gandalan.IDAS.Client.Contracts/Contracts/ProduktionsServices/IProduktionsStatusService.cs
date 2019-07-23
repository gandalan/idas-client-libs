using Gandalan.IDAS.WebApi.DTO;
using System;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsStatusService
    {
        void UpdateStatus(Guid positionsGuid, ProduktionsStatusHistorieDTO info);
        void UpdateStatus(Guid positionsGuid, SerieDTO serie);
        ProduktionsStatusDTO GetStatus(Guid positionsGuid);
    }
}

using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsStatusService
    {
        Task UpdateStatus(Guid positionsGuid, ProduktionsStatusHistorieDTO info);
        Task UpdateStatus(Guid positionsGuid, SerieDTO serie);
    }
}

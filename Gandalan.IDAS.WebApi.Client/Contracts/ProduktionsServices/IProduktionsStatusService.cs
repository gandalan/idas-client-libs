using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsStatusService
    {
        Task UpdateStatus(Guid positionsAVGuid, ProduktionsStatusHistorieDTO info);
        Task UpdateStatus(Guid positionsAVGuid, SerieDTO serie);
    }
}

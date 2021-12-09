using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsStatusService
    {
        Task UpdateStatus(Guid positionsAVGuid, ProduktionsStatusHistorieDTO info);
        Task UpdateStatus(Guid positionsAVGuid, SerieDTO serie);
    }
}

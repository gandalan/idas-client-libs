using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface IProduktionsDatenProcessor
    {
        Task<ProduktionsDatenDTO> Process(ProduktionsDatenDTO daten, BelegPositionAVDTO avPosition);
    }
}

using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV;

public interface IProduktionsDatenProcessor
{
    Task<ProduktionsDatenDTO> Process(ProduktionsDatenDTO daten, BelegPositionAVDTO avPosition, bool isDryRun);
}

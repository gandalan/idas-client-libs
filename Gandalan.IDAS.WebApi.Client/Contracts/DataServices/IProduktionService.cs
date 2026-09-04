using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices;

public interface IProduktionService
{
    Task<BerechnungResultDTO> GetDaten(BerechnungParameterDTO parameter);
    bool CanHandle(BelegPositionAVDTO avDTO);
    string TempFolder { get; set; }
}
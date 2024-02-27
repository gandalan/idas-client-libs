using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;

namespace Gandalan.Client.Contracts.DataServices
{

    public interface IProduktionService
    {
        Task<BerechnungResultDTO> GetDaten(BerechnungParameterDTO parameter);
        bool CanHandle(string variantenName);
        string TempFolder { get; set; }
    }
}

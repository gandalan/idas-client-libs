using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVBerechnungService
    {
        Task Execute(BerechnungParameterDTO parameter);

        Task Execute(BerechnungParameterDTO parameter, bool force = false);

        /// <summary>
        /// Zuletzt verwendeter Daten-Temp-Ordner (für Diagnosezwecke) 
        /// </summary>
        string TempFolder { get; set; }
    }
}

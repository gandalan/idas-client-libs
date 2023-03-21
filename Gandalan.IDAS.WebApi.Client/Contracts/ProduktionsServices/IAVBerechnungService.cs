using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVBerechnungService
    {        
        /// <summary>
        /// Zuletzt verwendeter Daten-Temp-Ordner (für Diagnosezwecke) 
        /// </summary>
        string TempFolder { get; set; }
        Task<BerechnungParameterDTO> Execute(BerechnungParameterDTO parameter);
    }
}

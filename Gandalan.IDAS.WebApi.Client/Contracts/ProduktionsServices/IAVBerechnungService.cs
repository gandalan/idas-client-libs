using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;

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

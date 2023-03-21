using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ISaegeDatenGenerator
    {
        /// <summary>
        /// Information zur Säge (Hersteller, Modellnummer usw.)
        /// </summary>
        string Modell { get; }
        /// <summary>
        /// Erzeugt die Sägedaten.
        /// </summary>
        /// <param name="avData">AV Daten zum Sägematerial</param>
        /// <param name="material"></param>
        /// <returns>Modellabhängige Daten zur Übermittlung an die Maschine</returns>
        string GenerateContent(SaegeKonfigurationDTO saegeKonfiguration, IList<BelegPositionAVDTO> avData, IList<MaterialbedarfDTO> material);

        string GenerateContent(SaegeKonfigurationDTO saegeKonfiguration, IList<SerienSaegelisteDataDTO> saegeDaten);
    }
}

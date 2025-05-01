using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices;

public interface ISaegeDatenGenerator
{
    /// <summary>
    /// Name der in den Settings angezeigt wird
    /// </summary>
    string DisplayName { get; }

    /// <summary>
    /// Information zur Säge (Hersteller, Modellnummer usw.) (interner Name, der nicht geändert werden darf, da die Settings die Säge über den Namen referenzieren)
    /// </summary>
    string Modell { get; }
    /// <summary>
    /// Dateiendung für die Sägedateien
    /// </summary>
    string DateiEndung { get; }

    /// <summary>
    /// Erzeugt die Sägedaten.
    /// </summary>
    /// <param name="saegeKonfiguration"></param>
    /// <param name="avData">AV Daten zum Sägematerial</param>
    /// <param name="material"></param>
    /// <returns>Modellabhängige Daten zur Übermittlung an die Maschine</returns>
    string GenerateContent(SaegeKonfigurationDTO saegeKonfiguration, IList<BelegPositionAVDTO> avData, IList<MaterialbedarfDTO> material);

    string GenerateContent(SaegeKonfigurationDTO saegeKonfiguration, IList<SerienSaegelisteDataDTO> saegeDaten);
}

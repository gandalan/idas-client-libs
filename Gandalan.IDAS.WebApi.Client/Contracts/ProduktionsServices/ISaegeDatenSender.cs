using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices;

/// <summary>
/// Sendet eine Sägedatei an die Maschine
/// </summary>
public interface ISaegeDatenSender
{
    /// <summary>
    /// Erstellt Sägedatei (per ISaegeDatenGenerator) für  und speichert die Datei unter dem angegebenen Dateinamen.
    /// </summary>
    /// <param name="saegeKonfiguration">Sägekonfiguration, die genutzt werden soll</param>
    /// <param name="saegeDaten">Sägelisten, für die die SägeDateien erzeugt werden sollen</param>
    IList<SaegeDatenResultDTO> GenerateAndSave(SaegeKonfigurationDTO saegeKonfiguration, IList<SerienSaegelisteDataDTO> saegeDaten);
}

using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Sendet eine Sägedatei an die Maschine
    /// </summary>
    public interface ISaegeDatenSender
    {
        /// <summary>
        /// Erstellt Sägedatei (per ISaegeDatenGenerator) und sendet diese an die Säge.
        /// </summary>
        /// <param name="saegeKonfiguration">Sägekonfiguration, die genutzt werden soll</param>
        /// <param name="avData">AV Daten zum Sägematerial</param>
        /// <param name="schnittListe">list der zu sägenden MaterialBedarfDTOs</param>
        void GenerateAndSend(SaegeKonfigurationDTO saegeKonfiguration, IList<BelegPositionAVDTO> avData, IList<MaterialbedarfDTO> schnittListe);

        /// <summary>
        /// Erstellt Sägedatei (per ISaegeDatenGenerator) für  und speichert die Datei unter dem angegebenen Dateinamen.
        /// </summary>
        /// <param name="saegeKonfiguration">Sägekonfiguration, die genutzt werden soll</param>
        /// <param name="saegeDaten">Sägelisten, für die die SägeDateien erzeugt werden sollen</param>
        void GenerateAndSave(SaegeKonfigurationDTO saegeKonfiguration, IList<SerienSaegelisteDataDTO> saegeDaten);
    }
}

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
        /// <param name="saegeDatenGenerator">Generator zur Erzeugung der maschinenspezifischen Daten</param>
        /// <param name="schnittListe">list der zu sägenden MaterialBedarfDTOs</param>
        void GenerateAndSend(ISaegeDatenGenerator saegeDatenGenerator, IList<MaterialbedarfDTO> schnittListe);

        /// <summary>
        /// Erstellt Sägedatei (per ISaegeDatenGenerator) für  und speichert die Datei unter dem angegebenen Dateinamen.
        /// </summary>
        /// <param name="saegeDatenGenerator">Generator zur Erzeugung der maschinenspezifischen Daten</param>
        /// <param name="schnittListe">list der zu sägenden MaterialBedarfDTOs</param>
        void GenerateAndSave(ISaegeDatenGenerator saegeDatenGenerator, SerienSaegelisteDataDTO saegeDaten, string fileName);
    }
}

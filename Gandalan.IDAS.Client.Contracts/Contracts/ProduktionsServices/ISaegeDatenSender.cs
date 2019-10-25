using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Sendet eine Sägeliste an die Maschine
    /// </summary>
    public interface ISaegeDatenSender
    {
        /// <summary>
        /// Erstellt Sägeliste (per ISaegeDatenGenerator) und sendet diese an die Säge.
        /// </summary>
        /// <param name="saegeDatenGenerator">Generator zur Erzeugung der maschinenspezifischen Daten</param>
        /// <param name="schnittListe">list der zu sägenden MaterialBedarfDTOs</param>
        void GenerateAndSend(ISaegeDatenGenerator saegeDatenGenerator, IList<MaterialbedarfDTO> schnittListe);
    }
}

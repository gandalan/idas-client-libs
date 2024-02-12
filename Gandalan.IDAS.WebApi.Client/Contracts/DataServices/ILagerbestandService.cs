using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    /// <summary>
    /// Interface für die Datenzugriffsebene der Bestandsverwaltung
    /// </summary>
    public interface ILagerbestandService
    {
        /// <summary>
        /// Ruft alle LagerbestandDTOs ab
        /// </summary>
        Task<List<LagerbestandDTO>> GetAllAsync();

        /// <summary>
        /// Legt ein neues LagerbestandDTO an, oder aktualisiert es, sofern bereits vorhanden
        /// </summary>
        /// <param name="lagerbestandDTO">LagerbestandDTO, das angelegt/aktualisiert werden soll</param>
        Task AddOrUpdateAsync(LagerbestandDTO lagerbestandDTO);

        /// <summary>
        /// Legt eine Liste neuer LagerbestandDTOs an, oder aktualisiert sie, sofern bereits vorhanden
        /// </summary>
        /// <param name="lagerbestandDTOs">Liste der LagerbestandDTOs, die angelegt/aktualisiert werden sollen</param>
        Task AddOrUpdateAsync(IList<LagerbestandDTO> lagerbestandDTOs);

        /// <summary>
        /// Entfernt das übergebene LagerbestandDTO
        /// </summary>
        /// <param name="lagerbestandDTO">LagerbestandDTO, das entfernt werden soll</param>
        Task DeleteAsync(LagerbestandDTO lagerbestandDTO);
    }
}

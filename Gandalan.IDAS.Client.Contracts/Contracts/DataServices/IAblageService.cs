using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    /// <summary>
    /// Interface für die Datenzugriffsebene der Ablageverwaltung
    /// </summary>
    public interface IAblageService
    {
        /// <summary>
        /// Ruft alle AblageDTOs ab
        /// </summary>
        Task<List<AblageDTO>> GetAllAsync();

        /// <summary>
        /// Legt ein neues AblageDTO an, oder aktualisiert es, sofern bereits vorhanden
        /// </summary>
        /// <param name="ablageDTO">AblageDTO, das angelegt/aktualisiert werden soll</param>        
        Task AddOrUpdateAsync(AblageDTO ablageDTO);

        /// <summary>
        /// Entfernt das übergebene AblageDTO
        /// </summary>
        /// <param name="ablageDTO">AblageDTO, das entfernt werden soll</param>
        Task DeleteAsync(AblageDTO ablageDTO);
    }
}

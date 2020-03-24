using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    /// <summary>
    /// Interface für die Datenzugriffsebene der InfoScreens
    /// </summary>
    public interface IInfoScreenService
    {
        /// <summary>
        /// Ruft alle InfoScreenConfigDTOs ab
        /// </summary>
        Task<List<InfoScreenConfigDTO>> GetAllAsync();

        /// <summary>
        /// Legt ein neues InfoScreenConfigDTO an, oder aktualisiert es, sofern bereits vorhanden
        /// </summary>
        /// <param name="infoScreenConfigDTO">InfoScreenConfigDTO, das angelegt/aktualisiert werden soll</param>        
        Task AddOrUpdateAsync(InfoScreenConfigDTO infoScreenConfigDTO);

        /// <summary>
        /// Entfernt das übergebene InfoScreenConfigDTO
        /// </summary>
        /// <param name="infoScreenConfigDTO">InfoScreenConfigDTO, das entfernt werden soll</param>
        Task DeleteAsync(InfoScreenConfigDTO infoScreenConfigDTO);
    }
}

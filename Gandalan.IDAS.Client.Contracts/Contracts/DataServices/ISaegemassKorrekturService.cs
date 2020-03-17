using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    /// <summary>
    /// Interface für die Datenzugriffsebene der Sägemaßkorrekturen
    /// </summary>
    public interface ISaegemassKorrekturService
    {
        /// <summary>
        /// Ruft alle SaegemassKorrekturDTOs ab
        /// </summary>
        Task<List<SaegemassKorrekturDTO>> GetAllAsync();

        /// <summary>
        /// Legt eine neue SaegemassKorrekturDTO an, oder aktualisiert es, sofern bereits vorhanden
        /// </summary>
        /// <param name="saegemassKorrekturDTO">SaegemassKorrekturDTO, das angelegt/aktualisiert werden soll</param>        
        Task AddOrUpdateAsync(SaegemassKorrekturDTO saegemassKorrekturDTO);

        /// <summary>
        /// Entfernt das übergebene SaegemassKorrekturDTO
        /// </summary>
        /// <param name="saegemassKorrekturDTO">SaegemassKorrekturDTO, das entfernt werden soll</param>
        Task DeleteAsync(SaegemassKorrekturDTO saegemassKorrekturDTO);
    }
}

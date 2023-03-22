using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Bereitet die EtikettDTOs für den Etikettendruck vor
    /// </summary>
    public interface IEtikettenDruckAufbereitung
    {
        /// <summary>
        /// Druckt die Etiketten zu den MaterialbedarfDTOs einer BelegPositionAVDTO
        /// </summary>
        /// <param name="typ">Etikettentyp der erzeugt werden soll</param>
        /// <param name="vorgang">VorgangListItemDTO der zu druckenden Etiketten</param>
        /// <param name="belegPosition">BelegPositionAVDTO der zu druckenden Etiketten</param>
        /// <param name="materialListe">Liste der MaterialbedarfDTOs, zu denen die Etiketten gedruckt werden sollen</param>
        Task<IList<EtikettDTO>> CreateEtiketten(VorgangListItemDTO vorgang, BelegPositionAVDTO belegPosition, List<MaterialbedarfDTO> materialListe, string typ = "Produktionsetikett");

        /// <summary>
        /// Druckt die Etiketten zu einer Liste von MaterialbedarfDTOs (auch Vorgangs-/Positionsübergreifend)
        /// </summary>
        /// <param name="avData">AV Daten zu den zu druckenden Etiketten</param>
        /// <param name="typ">Etikettentyp der erzeugt werden soll</param>
        /// <param name="materialListe">Liste der MaterialbedarfDTOs, zu denen die Etiketten gedruckt werden sollen</param>
        Task<IList<EtikettDTO>> CreateEtiketten(List<BelegPositionAVDTO> avData, List<MaterialbedarfDTO> materialListe, string typ = "Produktionsetikett");

        /// <summary>
        /// Druckt die angegebenen EtikettDTOs aus
        /// </summary>
        /// <param name="avData">AV Daten zu den zu druckenden Etiketten</param>
        /// <param name="typ">Etikettentyp der erzeugt werden soll</param>
        /// <param name="etikettListe">Liste mit EtikettDTOs, die gedruckt werden soll</param>
        Task<IList<EtikettDTO>> CreateEtiketten(List<BelegPositionAVDTO> avData, List<EtikettDTO> etikettListe, string typ = "Produktionsetikett");
    }
}

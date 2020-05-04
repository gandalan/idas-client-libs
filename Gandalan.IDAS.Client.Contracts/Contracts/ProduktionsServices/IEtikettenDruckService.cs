using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Druckt Produktionsetiketten zu einem Vorgang anhand dessen AV-/Materialbedarfsdaten
    /// </summary>
    public interface IEtikettenDruckService
    {
        /// <summary>
        /// Druckt die Etiketten zu den MaterialbedarfDTOs einer BelegPositionAVDTO
        /// </summary>
        /// <param name="vorgang">VorgangListItemDTO der zu druckenden Etiketten</param>
        /// <param name="belegPosition">BelegPositionAVDTO der zu druckenden Etiketten</param>
        /// <param name="materialListe">Liste der MaterialbedarfDTOs, zu denen die Etiketten gedruckt werden sollen</param>
        void PrintEtiketten(VorgangListItemDTO vorgang, BelegPositionAVDTO belegPosition, List<MaterialbedarfDTO> materialListe);

        /// <summary>
        /// Druckt die Etiketten zu einer Liste von MaterialbedarfDTOs (auch Vorgangs-/Positionsübergreifend)
        /// </summary>
        /// <param name="materialListe">Liste der MaterialbedarfDTOs, zu denen die Etiketten gedruckt werden sollen</param>
        void PrintEtiketten(List<MaterialbedarfDTO> materialListe);

        /// <summary>
        /// Druckt die angegebenen EtikettDTOs aus
        /// </summary>
        /// <param name="etikettListe">Liste mit EtikettDTOs, die gedruckt werden soll</param>
        void PrintEtiketten(List<EtikettDTO> etikettListe);
    }
}

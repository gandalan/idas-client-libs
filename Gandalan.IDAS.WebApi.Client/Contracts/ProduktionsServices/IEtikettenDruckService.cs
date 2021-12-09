using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Druckt Etiketten auf dem konfigurierten Labeldrucker
    /// </summary>
    public interface IEtikettenDruckService
    {
        /// <summary>
        /// Druckt die angegebenen EtikettDTOs aus
        /// </summary>
        /// <param name="titel">Titel für die Etiketten</param>
        /// <param name="etikettListe">Liste mit EtikettDTOs, die gedruckt werden soll</param>
        void PrintEtiketten(string titel, List<EtikettDTO> etikettListe);
    }
}

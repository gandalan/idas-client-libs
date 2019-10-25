using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Druckt Produktionsetiketten zu einem Vorgang anhand dessen AV-/Materialbedarfsdaten
    /// </summary>
    public interface IEtikettenDruck
    {
        void PrintEtiketten(VorgangListItemDTO vorgang, BelegPositionAVDTO belegPositionGuid, List<MaterialbedarfDTO> materialListe);
    }
}

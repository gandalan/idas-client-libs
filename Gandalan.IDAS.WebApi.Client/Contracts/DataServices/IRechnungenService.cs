using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.DataServices
{
    public interface IRechnungenService
    {
        Task<List<BelegeInfoDTO>> GetABFakturierbarListeAsync();
        Task<List<BelegeInfoDTO>> GetDruckbareRechnungenListeAsync(DateTime? printedSince = null);
        Task<List<BelegeInfoDTO>> GetExportierbareRechnungenListeAsync(DateTime? exportedSince = null);
        Task SetBelegePrintedAsync(List<Guid> belegListe);
        Task SetBelegeExportedAsync(List<Guid> belegListe);
        Task<Dictionary<Guid, Guid>> ErstelleRechnungenAsync(List<BelegartWechselDTO> belegeWechsel);
    }
}

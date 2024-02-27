using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;

namespace Gandalan.IDAS.WebApi.Client.Contracts.DataServices
{
    public interface ISammelrechnungenService
    {
        Task<SammelrechnungListItemDTO> ErstelleSammelrechnungenAsync(CreateSammelrechnungDTO dto);
        Task<List<SammelrechnungListItemDTO>> GetNotPrintedSammelrechnungenAsync(DateTime? printedSince = null);
        Task<List<SammelrechnungListItemDTO>> GetNotExportedSammelrechnungenAsync(DateTime? exportedSince = null);
        Task<SammelrechnungDTO> GetSammelrechnungAsync(Guid guid, bool includebelegDruckDTO = false);
        Task<List<BelegeInfoDTO>> GetPossibleSammelrechnungRechnungenAsync();
        Task<SammelrechnungDTO> UpdateSammelrechnungAsync(SammelrechnungDTO dto);
        Task AddRechnungToSammelrechnungenAsync(Guid belegGuid, Guid sammelrechnungGuid);
        Task SetSammelRechnungenAlsGedrucktAsync(List<Guid> sammelrechnungGuid, bool setEinzel = false);
        Task SetSammelRechnungenExportedAsync(List<Guid> sammelrechungGuid, bool setEinzel = false);
        Task<List<SammelrechnungListItemDTO>> SearchSammelrechnungAsync(string term);
    }
}

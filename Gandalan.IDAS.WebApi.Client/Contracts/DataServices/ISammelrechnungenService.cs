using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.DataServices
{
    public interface ISammelrechnungenService
    {
        Task<SammelrechnungListItemDTO> ErstelleSammelrechnungenAsync(CreateSammelrechnungDTO dto);
        Task<List<SammelrechnungListItemDTO>> GetSammelrechnungenAsync();
        Task<SammelrechnungDTO> GetSammelrechnungAsync(Guid guid, bool includebelegDruckDTO = false);
        Task<List<BelegeInfoDTO>> GetPossibleSammelrechnungRechnungenAsync();
        Task<SammelrechnungDTO> UpdateSammelrechnungAsync(SammelrechnungDTO dto);
        Task AddRechnungToSammelrechnungenAsync(Guid belegGuid, Guid sammelrechnungGuid);
    }
}

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SammelrechnungenWebRoutinen : WebRoutinenBase
    {
        public SammelrechnungenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<SammelrechnungListItemDTO> ErstelleSammelrechnungenAsync(CreateSammelrechnungDTO dto) 
            => await PostAsync<SammelrechnungListItemDTO>("Sammelrechnungen/ErstelleSammelrechnungen", dto);

        public async Task<List<SammelrechnungListItemDTO>> GetSammelrechnungenAsync() 
            => await GetAsync<List<SammelrechnungListItemDTO>>("Sammelrechnungen/GetSammelrechnungen");

        public async Task<SammelrechnungDTO> GetSammelrechnungAsync(Guid guid, bool includeBelegDruckDTO)
            => await GetAsync<SammelrechnungDTO>($"Sammelrechnungen/GetSammelrechnung?guid={guid}&includeBelegDruckDTO={includeBelegDruckDTO}");

        public async Task<List<BelegeInfoDTO>> GetPossibleSammelrechnungRechnungenAsync()
            => await GetAsync<List<BelegeInfoDTO>>("Sammelrechnungen/GetPossibleSammelrechnungRechnungen");
        
        public async Task<SammelrechnungDTO> UpdateSammelrechnungAsync(SammelrechnungDTO dto)
            => await PostAsync<SammelrechnungDTO>($"Sammelrechnungen/UpdateSammelrechnung", dto);

        public async Task<SammelrechnungListItemDTO> AddRechnungToSammelrechnungenAsync(Guid belegGuid, Guid sammelrechnungGuid) 
            => await PostAsync<SammelrechnungListItemDTO>($"Sammelrechnungen/AddRechnungToSammelrechnungen", 
                new AddRechnungSammelrechnungDTO() { BelegGuid = belegGuid, SammelrechnungGuid = sammelrechnungGuid });

        public async Task SetRechnungenAlsGedrucktAsync(Guid sammelrechnungGuid)
            => await PostAsync($"Sammelrechnungen/SetRechnungenAlsGedruckt?sammelrechnungGuid={sammelrechnungGuid}", null);
        
        public async Task SetRechnungenAlsFibuExportiertAsync(Guid sammelrechnungGuid)
            => await PostAsync($"Sammelrechnungen/SetRechnungenAlsFibuExportiert?sammelrechnungGuid={sammelrechnungGuid}", null);

        
    }
}

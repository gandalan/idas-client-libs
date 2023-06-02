using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Faktura;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FakturaWebRoutinen : WebRoutinenBase
    {
        public FakturaWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<List<VorgangDTO>> GetVorgaengeAsync(string kennzeichen)
            => await GetAsync<List<VorgangDTO>>($"Faktura/GetVorgaenge?kennzeichen={kennzeichen}");

        public async Task<string> GetVorgangKennzeichenAsync(Guid vorgangGuid)
            => await GetAsync<string>($"Faktura/GetVorgangKennzeichen?vorgangGuid={vorgangGuid}");

        public async Task<List<BelegDTO>> GetBelegeAsync(string kennzeichen)
            => await GetAsync<List<BelegDTO>>($"Faktura/GetBelege?kennzeichen={kennzeichen}");

        public async Task<string> GetBelegKennzeichenAsync(Guid belegGuid)
            => await GetAsync<string>($"Faktura/GetBelegKennzeichen?belegGuid={belegGuid}");

        public async Task<List<BelegPositionDTO>> GetBelegPositionenAsync(string kennzeichen)
            => await GetAsync<List<BelegPositionDTO>>($"Faktura/GetBelegPositionen?kennzeichen={kennzeichen}");

        public async Task<string> GetBelegPositionKennzeichenAsync(Guid belegPositionGuid)
            => await GetAsync<string>($"Faktura/GetBelegPositionKennzeichen?vorgangGuid={belegPositionGuid}");

        public async Task<List<BelegPositionAVDTO>> GetBelegPositionAVsAsync(string kennzeichen) 
            => await GetAsync<List<BelegPositionAVDTO>>($"Faktura/GetBelegPositionAVs?kennzeichen={kennzeichen}");

        public async Task<string> GetBelegPositionAVKennzeichenAsync(Guid belegPositionAvGuid) 
            => await GetAsync<string>($"Faktura/GetBelegPositionAVKennzeichen?vorgangGuid={belegPositionAvGuid}");

        public async Task<string> SetVorgangKennzeichenAsync(SetFakturaDTO dto)
            => await PostAsync<string>("Faktura/SetVorgangKennzeichen", dto);

        public async Task<string> SetBelegKennzeichenAsync(SetFakturaDTO dto)
            => await PostAsync<string>("Faktura/SetBelegKennzeichen", dto);

        public async Task<string> SetBelegPositionKennzeichenAsync(SetFakturaDTO dto) 
            => await PostAsync<string>("Faktura/SetBelegPositionKennzeichen", dto);

        public async Task<string> SetBelegPositionAVKennzeichenAsync(SetFakturaDTO dto) 
            => await PostAsync<string>("Faktura/SetBelegPositionAVKennzeichen", dto);
    }
}

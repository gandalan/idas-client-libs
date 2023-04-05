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

        public List<VorgangDTO> GetVorgaenge(string kennzeichen)
        {
            if (Login())
            {
                return Get<List<VorgangDTO>>($"Faktura/GetVorgaenge?kennzeichen={kennzeichen}");
            }
            return null;
        }

        public async Task<List<VorgangDTO>> GetVorgaengeAsync(string kennzeichen)
        {
            if (Login())
            {
                return await GetAsync<List<VorgangDTO>>($"Faktura/GetVorgaenge?kennzeichen={kennzeichen}");
            }
            return null;
        }

        public string GetVorgangKennzeichen(Guid vorgangGuid)
        {
            if (Login())
            {
                return Get<string>($"Faktura/GetVorgangKennzeichen?vorgangGuid={vorgangGuid}");
            }
            return null;
        }

        public async Task<string> GetVorgangKennzeichenAsync(Guid vorgangGuid)
        {
            if (Login())
            {
                return await GetAsync<string>($"Faktura/GetVorgangKennzeichen?vorgangGuid={vorgangGuid}");
            }
            return null;
        }

        public List<BelegDTO> GetBelege(string kennzeichen)
        {
            if (Login())
            {
                return Get<List<BelegDTO>>($"Faktura/GetBelege?kennzeichen={kennzeichen}");
            }
            return null;
        }

        public async Task<List<BelegDTO>> GetBelegeAsync(string kennzeichen)
        {
            if (Login())
            {
                return await GetAsync<List<BelegDTO>>($"Faktura/GetBelege?kennzeichen={kennzeichen}");
            }
            return null;
        }

        public string GetBelegKennzeichen(Guid belegGuid)
        {
            if (Login())
            {
                return Get<string>($"Faktura/GetBelegKennzeichen?belegGuid={belegGuid}");
            }
            return null;
        }

        public async Task<string> GetBelegKennzeichenAsync(Guid belegGuid)
        {
            if (Login())
            {
                return await GetAsync<string>($"Faktura/GetBelegKennzeichen?belegGuid={belegGuid}");
            }
            return null;
        }

        public List<BelegPositionDTO> GetBelegPositionen(string kennzeichen)
        {
            if (Login())
            {
                return Get<List<BelegPositionDTO>>($"Faktura/GetBelegPositionen?kennzeichen={kennzeichen}");
            }
            return null;
        }

        public async Task<List<BelegPositionDTO>> GetBelegPositionenAsync(string kennzeichen)
        {
            if (Login())
            {
                return await GetAsync<List<BelegPositionDTO>>($"Faktura/GetBelegPositionen?kennzeichen={kennzeichen}");
            }
            return null;
        }

        public string GetBelegPositionKennzeichen(Guid belegPositionGuid)
        {
            if (Login())
            {
                return Get<string>($"Faktura/GetBelegPositionKennzeichen?vorgangGuid={belegPositionGuid}");
            }
            return null;
        }

        public async Task<string> GetBelegPositionKennzeichenAsync(Guid belegPositionGuid)
        {
            if (Login())
            {
                return await GetAsync<string>($"Faktura/GetBelegPositionKennzeichen?vorgangGuid={belegPositionGuid}");
            }
            return null;
        }

        public List<BelegPositionAVDTO> GetBelegPositionAVs(string kennzeichen)
        {
            if (Login())
            {
                return Get<List<BelegPositionAVDTO>>($"Faktura/GetBelegPositionAVs?kennzeichen={kennzeichen}");
            }
            return null;
        }

        public async Task<List<BelegPositionAVDTO>> GetBelegPositionAVsAsync(string kennzeichen)
        {
            if (Login())
            {
                return await GetAsync<List<BelegPositionAVDTO>>($"Faktura/GetBelegPositionAVs?kennzeichen={kennzeichen}");
            }
            return null;
        }

        public string GetBelegPositionAVKennzeichen(Guid belegPositionAvGuid)
        {
            if (Login())
            {
                return Get<string>($"Faktura/GetBelegPositionAVKennzeichen?vorgangGuid={belegPositionAvGuid}");
            }
            return null;
        }

        public async Task<string> GetBelegPositionAVKennzeichenAsync(Guid belegPositionAvGuid)
        {
            if (Login())
            {
                return await GetAsync<string>($"Faktura/GetBelegPositionAVKennzeichen?vorgangGuid={belegPositionAvGuid}");
            }
            return null;
        }

        public string SetVorgangKennzeichen(SetFakturaDTO dto)
        {
            if (Login())
            {
                return Post<string>("Faktura/SetVorgangKennzeichen", dto);
            }
            return "Not logged in";
        }

        public async Task<string> SetVorgangKennzeichenAsync(SetFakturaDTO dto)
        {
            if (Login())
            {
                return await PostAsync<string>("Faktura/SetVorgangKennzeichen", dto);
            }
            return "Not logged in";
        }

        public string SetBelegKennzeichen(SetFakturaDTO dto)
        {
            if (Login())
            {
                return Post<string>("Faktura/SetBelegKennzeichen", dto);
            }
            return "Not logged in";
        }

        public async Task<string> SetBelegKennzeichenAsync(SetFakturaDTO dto)
        {
            if (Login())
            {
                return await PostAsync<string>("Faktura/SetBelegKennzeichen", dto);
            }
            return "Not logged in";
        }

        public string SetBelegPositionKennzeichen(SetFakturaDTO dto)
        {
            if (Login())
            {
                return Post<string>("Faktura/SetBelegPositionKennzeichen", dto);
            }
            return "Not logged in";
        }

        public async Task<string> SetBelegPositionKennzeichenAsync(SetFakturaDTO dto)
        {
            if (Login())
            {
                return await PostAsync<string>("Faktura/SetBelegPositionKennzeichen", dto);
            }
            return "Not logged in";
        }

        public string SetBelegPositionAVKennzeichen(SetFakturaDTO dto)
        {
            if (Login())
            {
                return Post<string>("Faktura/SetBelegPositionAVKennzeichen", dto);
            }
            return "Not logged in";
        }

        public async Task<string> SetBelegPositionAVKennzeichenAsync(SetFakturaDTO dto)
        {
            if (Login())
            {
                return await PostAsync<string>("Faktura/SetBelegPositionAVKennzeichen", dto);
            }
            return "Not logged in";
        }
    }
}

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
using Gandalan.IDAS.WebApi.DTO;
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

        public SammelrechnungListItemDTO ErstelleSammelrechnungen(CreateSammelrechnungDTO dto)
        {
            if (Login())
            {
                return Post<SammelrechnungListItemDTO>("Sammelrechnungen/ErstelleSammelrechnungen", dto);
            }
            return null;
        }

        public List<SammelrechnungListItemDTO> GetSammelrechnungen()
        {
            if (Login())
            {
                return Get<List<SammelrechnungListItemDTO>>("Sammelrechnungen/GetSammelrechnungen");
            }
            return null;
        }

        public SammelrechnungDTO GetSammelrechnung(Guid guid)
        {
            if (Login())
            {
                return Get<SammelrechnungDTO>($"Sammelrechnungen/GetSammelrechnung?guid={guid}");
            }
            return null;
        }

        public List<BelegeInfoDTO> GetPossibleSammelrechnungRechnungen()
        {
            if (Login())
            {
                return Get<List<BelegeInfoDTO>>("Sammelrechnungen/GetPossibleSammelrechnungRechnungen");
            }
            return null;
        }
        public SammelrechnungDTO UpdateSammelrechnung(SammelrechnungDTO dto)
        {
            if (Login())
            {
                return Post<SammelrechnungDTO>("Sammelrechnungen/UpdateSammelrechnung", dto);
            }
            return null;
        }

        public async Task<SammelrechnungListItemDTO> ErstelleSammelrechnungenAsync(CreateSammelrechnungDTO dto)
        {
            return await Task.Run(() => ErstelleSammelrechnungen(dto));
        }

        public async Task<List<SammelrechnungListItemDTO>> GetSammelrechnungenAsync()
        {
            return await Task.Run(() => GetSammelrechnungen());
        }

        public async Task<SammelrechnungDTO> GetSammelrechnungAsync(Guid guid)
        {
            return await Task.Run(() => GetSammelrechnung(guid));
        }

        public async Task<List<BelegeInfoDTO>> GetPossibleSammelrechnungRechnungenAsync()
        {
            return await Task.Run(() => GetPossibleSammelrechnungRechnungen());
        }

        public async Task<SammelrechnungDTO> UpdateSammelrechnungAsync(SammelrechnungDTO dto)
        {
            return await Task.Run(() => UpdateSammelrechnung(dto));
        }
    }
}

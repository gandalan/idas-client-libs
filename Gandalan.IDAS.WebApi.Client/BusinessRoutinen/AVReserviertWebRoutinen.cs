using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.Data.DTOs.AV;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AVReserviertWebRoutinen : WebRoutinenBase
    {
        public AVReserviertWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public AVReserviertItemDTO[] GetAllAVReserviertItems()
        {
            if (Login())
            {
                return Get<AVReserviertItemDTO[]>("AVReserviert");
            }
            return null;
        }

        public AVReserviertItemDTO[] GetAllAVReserviertItemsBySerie(Guid serieGuid)
        {
            if (Login())
            {
                return Get<AVReserviertItemDTO[]>($"AVReserviert/?serieGuid={serieGuid}");
            }
            return null;
        }



        public async Task<AVReserviertItemDTO[]> GetAllAVReserviertItemsAsync()
        {
            if (Login())
            {
                return await GetAsync<AVReserviertItemDTO[]>("AVReserviert");
            }
            return null;
        }

        public async Task<AVReserviertItemDTO[]> GetAllAVReserviertItemsBySerieAsync(Guid serieGuid)
        {
            if (Login())
            {
                return await GetAsync<AVReserviertItemDTO[]>($"AVReserviert/?serieGuid={serieGuid}");
            }
            return null;
        }
    }
}

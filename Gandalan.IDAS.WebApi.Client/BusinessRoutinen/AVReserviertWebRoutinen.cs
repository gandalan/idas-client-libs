using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.AV;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AVReserviertWebRoutinen : WebRoutinenBase
    {
        public AVReserviertWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<AVReserviertItemDTO[]> GetAllAVReserviertItemsAsync()
        {
            return await GetAsync<AVReserviertItemDTO[]>("AVReserviert");
        }

        public async Task<AVReserviertItemDTO[]> GetAllAVReserviertItemsBySerieAsync(Guid serieGuid)
        {
            return await GetAsync<AVReserviertItemDTO[]>($"AVReserviert/?serieGuid={serieGuid}");
        }
    }
}

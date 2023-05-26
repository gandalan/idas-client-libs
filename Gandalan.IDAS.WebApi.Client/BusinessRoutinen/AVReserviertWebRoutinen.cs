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

        public async Task<AVReserviertItemDTO[]> GetAllAVReserviertItems()
        {
            return await GetAsync<AVReserviertItemDTO[]>("AVReserviert");
        }

        public async Task<AVReserviertItemDTO[]> GetAllAVReserviertItemsBySerie(Guid serieGuid)
        {
            return await GetAsync<AVReserviertItemDTO[]>($"AVReserviert/?serieGuid={serieGuid}");
        }
    }
}

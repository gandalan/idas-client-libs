using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.AV;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface IAVReserviertService
    {
        Task<List<AVReserviertItemDTO>> GetAll();
        Task<List<AVReserviertItemDTO>> GetAll(Guid serieGuid);
    }
}

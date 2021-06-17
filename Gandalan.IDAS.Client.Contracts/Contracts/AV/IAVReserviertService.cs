using Gandalan.IDAS.WebApi.Data.DTOs.AV;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface IAVReserviertService
    {

        Task<List<AVReserviertItemDTO>> GetAll();
        Task<List<AVReserviertItemDTO>> GetAll(Guid serieGuid);

    }
}

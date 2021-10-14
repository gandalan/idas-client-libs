using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IAVKalenderKennzeichenService
    {
        Task<List<AVKalenderKennzeichenDTO>> GetAllAsync(DateTime fromDate, DateTime toDate);
        Task<AVKalenderKennzeichenDTO> SaveAsync(AVKalenderKennzeichenDTO kennzeichen);
        Task DeleteAsync(Guid guid);        
    }
}
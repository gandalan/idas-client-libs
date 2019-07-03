using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.DataServices
{
    public interface IKundenService 
    {
        Task<KontaktListItemDTO[]> GetAllAsync();
        Task<KontaktDTO> SaveAsync(KontaktDTO kunde);
        Task<KontaktDTO> LoadAsync(Guid guid);        
    }
}
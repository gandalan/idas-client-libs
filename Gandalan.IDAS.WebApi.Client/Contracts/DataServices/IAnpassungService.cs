using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IAnpassungService
    {
        Task<AnpassungDTO[]> GetAllAsync();
        Task<AnpassungDTO[]> GetAsync(AnpassungArtDTO art);
        Task SaveAsync(AnpassungDTO anpassung);
        Task DeleteAsync(Guid anpassungGuid);
    }
}

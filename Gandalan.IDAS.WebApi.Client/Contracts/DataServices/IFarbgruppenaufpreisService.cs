using Gandalan.IDAS.WebApi.Data.DTOs.Farben;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IFarbgruppenaufpreisService
    {
        Task<List<FarbgruppenaufpreiseDTO>> GetAsync();
        Task SaveAsync(FarbgruppenaufpreiseDTO aufpreis);
    }
}

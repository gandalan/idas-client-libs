using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.Farben;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices;

public interface IFarbgruppenaufpreisService
{
    Task<List<FarbgruppenaufpreiseDTO>> GetAsync();
    Task SaveAsync(FarbgruppenaufpreiseDTO aufpreis);
}
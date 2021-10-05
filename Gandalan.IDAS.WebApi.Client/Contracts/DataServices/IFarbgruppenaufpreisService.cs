using Gandalan.IDAS.WebApi.Data.DTOs.Farben;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IFarbgruppenaufpreisService
    {
        Task<List<FarbgruppenaufpreiseDTO>> GetAsync();
        Task SaveAsync(FarbgruppenaufpreiseDTO aufpreis);
    }
}

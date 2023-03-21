using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IIndiService
    {
        Task<List<IndiPropertyListDTO>> GetAll();
        Task<IndiPropertyListDTO> GetIndiPropertyList(string propertyListTitle);
        Task SaveAll(List<IndiPropertyListDTO> list);
    }
}

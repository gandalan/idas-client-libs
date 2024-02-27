using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IMaterialienService
    {
        Task<MaterialDTO[]> GetMaterialien();
    }
}

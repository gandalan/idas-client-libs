using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IMaterialienService
    {
        Task<MaterialDTO[]> GetMaterialien();
    }
}

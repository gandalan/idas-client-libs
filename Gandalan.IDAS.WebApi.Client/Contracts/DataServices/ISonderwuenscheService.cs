using Gandalan.IDAS.WebApi.Data.DTO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface ISonderWuenscheService
    {
        Task<VarianteSonderWunschDTO[]> GetAllSonderWuenscheAsync();
        Task<BelegPositionSonderwunschWerteListeDTO[]> GetAllSonderWuenscheWerteListenAsync();
        Task<VarianteSonderWunschDTO> GetAllSonderWuenscheFromVariante(string variantenName);
        Task<BelegPositionSonderwunschDTO[]> GetEigenschaftenFromImport(string ImportName);
    }
}

using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge
{
    public interface IBelegpositionPreisService
    {
        Task<bool> RecalculatePreis(BelegPositionDTO pos);
    }
}

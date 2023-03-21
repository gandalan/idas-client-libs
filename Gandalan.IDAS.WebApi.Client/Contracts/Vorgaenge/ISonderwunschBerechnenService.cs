using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge
{
    public interface ISonderwunschBerechnenService
    {
        Task<bool> RecalculateSonderwuensche(BelegPositionDTO pos);
    }
}

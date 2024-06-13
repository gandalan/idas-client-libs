using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge;

public interface ISonderwunschBerechnenService
{
    Task<bool> RecalculateSonderwuensche(BelegPositionDTO pos);
}
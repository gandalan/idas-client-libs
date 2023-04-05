using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IMaterialListeDisplay
    {
        Task Execute(BelegPositionAVDTO dto);
    }
}
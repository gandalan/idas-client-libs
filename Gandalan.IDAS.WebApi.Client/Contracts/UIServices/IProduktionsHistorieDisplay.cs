using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IProduktionsHistorieDisplay
    {
        Task Display(Guid BelegPositionsGuid);
    }
}

using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IKundeDisplay
    {
        Task DisplayKunde(Guid kundeGuid);
    }
}

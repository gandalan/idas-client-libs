using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IKundeDisplay
    {
        Task DisplayKunde(Guid kundeGuid);
    }
}

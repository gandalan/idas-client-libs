using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IKundeEditor : ILockedPanel
    {
        Task EditKunde(Guid kundeGuid);
    }
}

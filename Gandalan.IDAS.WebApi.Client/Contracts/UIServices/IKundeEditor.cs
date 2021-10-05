using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IKundeEditor
    {
        Task EditKunde(Guid kundeGuid);
    }
}

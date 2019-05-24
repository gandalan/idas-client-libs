using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IKundeEditor
    {
        Task EditKunde(Guid kundeGuid);
    }
}

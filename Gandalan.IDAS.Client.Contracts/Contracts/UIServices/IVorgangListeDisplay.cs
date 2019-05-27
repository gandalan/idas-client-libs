using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IVorgangListeDisplay
    {
        Task DisplayVorgaenge();
        Task DisplayVorgaengeByKunde(Guid kundeGuid);
    }
}

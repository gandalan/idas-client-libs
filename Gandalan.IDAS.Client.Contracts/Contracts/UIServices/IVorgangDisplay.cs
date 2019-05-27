using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IVorgangDisplay
    {
        Task DisplayVorgang(Guid vorgangGuid);
    }
}

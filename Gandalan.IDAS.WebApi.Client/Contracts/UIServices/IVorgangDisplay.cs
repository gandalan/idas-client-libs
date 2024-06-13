using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices;

public interface IVorgangDisplay
{
    Task DisplayVorgang(Guid vorgangGuid, bool clearHistory = false, Func<Task> historyOverride = null);
}
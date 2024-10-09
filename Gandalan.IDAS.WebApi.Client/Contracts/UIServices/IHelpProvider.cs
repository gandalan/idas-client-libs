using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices;

public interface IHelpProvider
{
    Task ShowChangelog(string application);
    Task ShowTooltip(string slug);
    Task ShowContextHelp(string slug);
    [Obsolete("Use ShowHelpCenter(string application) instead.")]
    Task ShowHelpCenter();
    Task ShowHelpCenter(string application, bool clearHistory = true);
}

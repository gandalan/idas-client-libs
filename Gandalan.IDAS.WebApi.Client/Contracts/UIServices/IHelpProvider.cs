using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IHelpProvider
    {
        Task ShowChangelog();
        Task ShowTooltip(string slug);
        Task ShowContextHelp(string slug);
    }
}

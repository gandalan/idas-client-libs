using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IHelpProvider
    {
        Task ShowChangelog(string application);
        Task ShowTooltip(string slug);
        Task ShowContextHelp(string slug);
        Task ShowHelpCenter();
    }
}

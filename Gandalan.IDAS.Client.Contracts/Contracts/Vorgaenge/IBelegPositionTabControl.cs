using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Vorgaenge
{
    public interface IBelegPositionTabControl
    {
        string TabCaption { get; }
        int Order { get; }

        Task OnSave();
    }
}

using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.AV;

public interface IKapaTabControl
{
    string TabCaption { get; }
    int Order { get; }
    bool DisableZeitraum { get; }

    Task Load();
}
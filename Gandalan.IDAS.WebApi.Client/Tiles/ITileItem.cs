using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Tiles
{
    public interface ITileItem
    {
        string Icon { get; set; }
        string HeadLine { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        object Control { get; set; }
        string Group { get; set; }
        object StateColor { get; set; }
        int Order { get; set; }
        bool IsVisible { get; set; }
        bool StrechVertically { get; set; }

        Task Load();
        Task UnLoad();
    }
}

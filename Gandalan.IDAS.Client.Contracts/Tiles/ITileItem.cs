using System.Drawing;
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
        Color StateColor { get; set; }

        Task Load();
    }
}

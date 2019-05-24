using System;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gandalan.Client.Common.Tiles
{
	public interface ITileItem
	{
		string Icon { get; set; }
		string HeadLine { get; set; }
		string Description { get; set; }
		string Name { get; set; }
		object Control { get; set; }
        string Group { get; set; }
        SolidColorBrush StateColor { get; set; }

        Task Load();
    }
}

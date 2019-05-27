using System.Collections.Generic;

namespace Gandalan.Client.Common.Tiles
{
	public interface ITileManager
	{
		void AddTile(ITileItem tileItem);
		List<ITileItemGroup> GetTileGroups();
	}
}

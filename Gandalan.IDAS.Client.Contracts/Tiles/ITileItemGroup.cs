using System.Collections.Generic;

namespace Gandalan.Client.Common.Tiles
{
	public interface ITileItemGroup
	{
		List<ITileItem> Tiles { get; set; }
		string Name { get; set; }
	}
}

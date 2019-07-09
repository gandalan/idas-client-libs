using System.Collections.Generic;

namespace Gandalan.Client.Contracts.Tiles
{
	public interface ITileItemGroup
	{
		List<ITileItem> Tiles { get; set; }
		string Name { get; set; }
	}
}

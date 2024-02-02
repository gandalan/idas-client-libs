using System.Collections.Generic;

namespace Gandalan.Client.Contracts.Tiles
{
    public interface ITileManager
    {
        void AddTile(ITileItem tileItem);
        List<ITileItemGroup> GetTileGroups();
    }
}

using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Tiles;

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

    /// <summary>
    /// Streckt das Tile in der Höhe. Wie System.Windows.GridUnitType.Star.
    /// Alle Tiles in einer Gruppe müssen diese Flag gesetzt haben.
    /// </summary>
    bool StretchVertically { get; set; }

    /// <summary>
    /// Minimale Höhe für Tile, wenn StretchVertically gesetzt ist.
    /// Der Gröste Wert innerhalb der Gruppe wird verwendet.
    /// </summary>
    double MinHeight { get; set; }

    Task Load();
    Task UnLoad();
}
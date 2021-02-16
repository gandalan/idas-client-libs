using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface IPositionSerieItem
    {
        Guid BelegPositionGuid { get; set; }
        string Position { get; set; }
        int Menge { get; set; }
        int Vorlauf { get; set; }
        string SerieAuslastung { get; set; }
        Guid SerieGuid { get; set; }
        DateTime ProduktionsDatum { get; set; }
        DateTime LieferDatum { get; set; }
        string PositionInfo { get; set; }
        decimal KapBedarf { get; set; }
        decimal KapBedarfGes { get; set; }
        bool HatNachfolgeBelegPosition { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion.TrafficLight;

public class PositionTrafficLightDTO
{
    public Guid BelegPositionGuid { get; set; }
    public string PositionsNummer { get; set; }
    public TrafficLightRelation Relation { get; set; }
    public TrafficLightStatus Status { get; set; }
    public List<TrafficLightReasonDTO> Reasons { get; set; } = [];

    /// <summary>
    /// Namen aller Serien, in denen Elemente der Position stecken, auch wenn sie keinen Grund auslösen (z. B. für den Hinweis in der Löschabfrage).
    /// </summary>
    public List<string> Serien { get; set; } = [];
}

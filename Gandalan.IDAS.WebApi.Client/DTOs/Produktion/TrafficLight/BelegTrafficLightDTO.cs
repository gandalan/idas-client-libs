using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion.TrafficLight;

public class BelegTrafficLightDTO
{
    public Guid BelegGuid { get; set; }
    public string BelegArt { get; set; }
    public long BelegNummer { get; set; }
    public TrafficLightStatus Status { get; set; }

    /// <summary>
    /// Nur Gründe zum Beleg selbst (beim Löschen). Die Gründe der Positionen stehen an den Positionen und fließen nur über
    /// <see cref="Status"/> in den Beleg ein.
    /// </summary>
    public List<TrafficLightReasonDTO> Reasons { get; set; } = [];

    public List<PositionTrafficLightDTO> Positionen { get; set; } = [];
}

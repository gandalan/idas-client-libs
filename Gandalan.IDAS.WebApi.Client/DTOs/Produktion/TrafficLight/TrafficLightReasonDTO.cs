namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion.TrafficLight;

public class TrafficLightReasonDTO
{
    /// <summary>
    /// Bewusst string statt Enum: Neue Kriterien sollen ältere Clients nicht brechen. Bekannte Werte siehe <see cref="TrafficLightReasonCodes"/>.
    /// </summary>
    public string Code { get; set; }
    public TrafficLightStatus Status { get; set; }
    public string Text { get; set; }
}

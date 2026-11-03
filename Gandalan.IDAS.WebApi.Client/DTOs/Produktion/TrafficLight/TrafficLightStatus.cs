namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion.TrafficLight;

// Aufsteigend nach Schwere: Der zusammengefasste Status ist immer der höchste Wert.
// Die Zahlenwerte gehen so über die Leitung und bestimmen die Rangfolge, deshalb nie umnummerieren.
public enum TrafficLightStatus
{
    Green = 0,
    Yellow = 1,
    Red = 2,
}

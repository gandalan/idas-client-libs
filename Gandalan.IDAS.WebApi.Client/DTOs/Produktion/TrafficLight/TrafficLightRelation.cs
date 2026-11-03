namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion.TrafficLight;

public enum TrafficLightRelation
{
    /// <summary>
    /// Die angefragte Position bzw. eine Position des Belegs, der gelöscht werden soll.
    /// </summary>
    Target = 0,
    Ancestor = 1,
    Descendant = 2,
}

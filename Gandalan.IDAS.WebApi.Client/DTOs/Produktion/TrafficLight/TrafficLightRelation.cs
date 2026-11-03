namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion.TrafficLight;

public enum TrafficLightRelation
{
    /// <summary>
    /// Die angefragte Position bzw. eine Position des Belegs, der gelöscht werden soll.
    /// </summary>
    Target = 0,
    Ancestor = 1,
    Descendant = 2,

    /// <summary>
    /// Hängt unter demselben obersten Vorgänger, ist aber weder Vorgänger noch Nachfolger der angefragten Position, z. B. die
    /// Rechnung neben dem PA unter derselben AB-Position.
    /// </summary>
    Sibling = 3,
}

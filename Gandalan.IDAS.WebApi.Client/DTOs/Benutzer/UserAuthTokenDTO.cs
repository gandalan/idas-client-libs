using System;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Informationen über eine erfolgreiche Anmeldung am System.
/// </summary>
public class UserAuthTokenDTO
{
    /// <summary>
    /// Token der Anwendung, die den Zugriff initiiert. Regelt Login- und
    /// Zugriffsberechtigungen des Anwenders innerhalb der API.
    /// </summary>
    public Guid AppToken { get; set; }

    /// <summary>
    /// Ablaufdatum, ab dem das Token ungültig wird. Die Anwendung muss
    /// sich dann erneut einloggen
    /// </summary>
    public DateTime Expires { get; set; }

    /// <summary>
    /// Das erzeugte Token, das für weitere Requests an die API mitgesendet
    /// werden muss
    /// </summary>
    public Guid Token { get; set; }

    /// <summary>
    /// Benutzerobjekt, ggf. inkl. Rollen und Berechtigungen des Users
    /// </summary>
    public BenutzerDTO Benutzer { get; set; }

    /// <summary>
    /// Mandant, unter dem der Benutzer angemeldet wurde
    /// </summary>
    public Guid MandantGuid { get; set; }

    /// <summary>
    /// Mandanten-Objekt des Benutzers
    /// </summary>
    public MandantDTO Mandant { get; set; }
}
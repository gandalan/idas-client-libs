using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.DTO;

public class PersonDTO : IDTOWithApplicationSpecificProperties
{
    /// <summary>
    /// Eindeutige GUID
    /// </summary>
    public Guid PersonGuid { get; set; }

    /// <summary>
    /// Nachname der Person
    /// </summary>
    public string Nachname { get; set; }

    /// <summary>
    /// Vorname/Rufname der Person
    /// </summary>
    public string Vorname { get; set; }

    /// <summary>
    /// evtl. weitere Vornamen
    /// </summary>
    public string WeitereVornamen { get; set; }

    /// <summary>
    /// Geburtstag
    /// </summary>
    public DateTime? Geburtstag { get; set; }

    public string Briefanrede { get; set; }
    public string Anrede { get; set; }
    public string Mailadresse { get; set; }
    public string Landesvorwahl { get; set; }
    public string Vorwahl { get; set; }
    public string Telefonnummer { get; set; }
    public string Durchwahl { get; set; }
    public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }

    /// <summary>
    /// Inaktiv Kennzeichen
    /// </summary>
    public bool IstInaktiv { get; set; }
}

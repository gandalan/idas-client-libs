using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.DTO;

public class BaseListItemDTO : IDTOWithApplicationSpecificProperties, IDTOWithAdditionalProperties
{
    /// <summary>
    /// Eindeutige GUID des Vorgangs
    /// </summary>
    public Guid VorgangGuid { get; set; }
    /// <summary>
    /// Eindeutige GUID des Bestellscheins
    /// </summary>
    public Guid BelegGuid { get; set; }
    /// <summary>
    /// Sichtbare Vorgangsnummer/zur Info für Kunden usw.
    /// </summary>
    public long VorgangsNummer { get; set; }
    public long BelegNummer { get; set; }
    public long BelegJahr { get; set; }
    /// <summary>
    /// Erstelldatum des Vorgangs
    /// </summary>
    public DateTime ErstellDatum { get; set; }
    /// <summary>
    /// Datum der letzten Änderung
    /// </summary>
    public DateTime AenderungsDatum { get; set; }
    /// <summary>
    /// Name des Kunden für Anzeige
    /// </summary>
    public string Kundenname { get; set; }
    /// <summary>
    /// Adresse des detaillierten Beleg-Objektes (gSQL)
    /// </summary>
    public string URL { get; set; }
    public string Status { get; set; }
    public int AnzahlNachrichten { get; set; }

    public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
    public Dictionary<string, PropertyValueCollection> AdditionalProperties { get; set; }
}

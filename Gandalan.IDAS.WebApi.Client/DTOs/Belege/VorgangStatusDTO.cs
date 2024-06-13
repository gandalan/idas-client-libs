using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class VorgangStatusDTO
{
    /// <summary>
    /// Eindeutige GUID
    /// </summary>
    public Guid VorgangGuid { get; set; }

    /// <summary>
    /// Sichtbare Vorgangsnummer/zur Info für Kunden usw.
    /// </summary>
    public long VorgangsNummer { get; set; }

    /// <summary>
    /// Statuscode
    /// </summary>
    public string AktuellerStatus { get; set; }

    /// <summary>
    /// Datum der letzten Änderung des Vorgangs
    /// </summary>
    public DateTime AenderungsDatum { get; set; }

    public string NeuerStatus { get; set; }
}
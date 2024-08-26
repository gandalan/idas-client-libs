using System;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// VorgangStatusTableDTO welches für die Functions benötigt wird
/// </summary>
public class VorgangStatusTableDTO
{
    /// <summary>
    /// Eindeutige GUID des Vorgangs
    /// </summary>
    public Guid VorgangGuid { get; set; }

    /// <summary>
    /// Eindeutige GUID des Kontaktes im Vorgang
    /// </summary>
    public Guid? KontaktGuid { get; set; }

    /// <summary>
    /// Ob der Kunde geändert wurde, auch bei Neuanlöage = true
    /// </summary>
    public bool KundeGeaendert { get; set; }

    /// <summary>
    /// Datum der letzten Änderung des Vorgangs
    /// </summary>
    public DateTime AenderungsDatum { get; set; }

    /// <summary>
    /// Die ID des Mandanten wird für die Functions benötigt
    /// </summary>
    public long MandantId { get; set; }
}
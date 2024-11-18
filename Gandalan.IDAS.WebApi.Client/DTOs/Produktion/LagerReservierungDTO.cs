using System;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// DTO für die LagerReservierungen
/// </summary>
public class LagerReservierungDTO
{
    public Guid LagerReservierungGuid { get; set; }
    public string Artikelnummer { get; set; }
    public string FarbKuerzel { get; set; }
    public string FarbCode { get; set; }
    public string Bezug { get; set; }

    public decimal Menge { get; set; }
    public string Einheit { get; set; }
    public DateTime ErstellDatum { get; set; }

    public string WindowsUser { get; set; }
    public string ArtosUser { get; set; }

    public DateTime ChangedDate { get; set; }
    public long Version { get; set; }
}

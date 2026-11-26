using System;
using Gandalan.IDAS.WebApi.Data.DTOs.Belege;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Ein Beleg, in den eine Position kopiert wird (Route PositionInBelegeUebernehmen).
/// </summary>
public class PositionUebernahmeZielDTO
{
    /// <summary>
    /// Bestehender Beleg. <see cref="Guid.Empty"/> legt einen neuen Beleg der <see cref="BelegArt"/> an.
    /// </summary>
    public Guid BelegGuid { get; set; }

    /// <summary>
    /// Nur für einen neuen Beleg. Für einen neuen Produktionsbeleg steht <c>ProduktionsAuftrag</c>; ob PA, ZA, VA oder FF-Auftrag entsteht,
    /// wählt die Produktionsfreigabe nach der Art der Position.
    /// </summary>
    public BelegArt? BelegArt { get; set; }

    /// <summary>
    /// Nur für einen neuen Beleg anstelle einer Position, die sich nicht ändern lässt (z. B. Rechnung mit FakturaKennzeichen):
    /// Der neue Beleg bekommt deren Belegart, die Kopie hängt an deren Vorgänger.
    /// </summary>
    public Guid? StattBelegPositionGuid { get; set; }
}

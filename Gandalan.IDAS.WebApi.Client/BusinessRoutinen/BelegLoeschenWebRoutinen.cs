// Gandalan GmbH & Co. KG - (c) 2019
// Middleware//Gandalan.IDAS.WebApi.Client//BelegArtWebRoutinen.cs
// Created: 13.06.2019 Konstantin Tümmler

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegLoeschenWebRoutinen : WebRoutinenBase
{
    public BelegLoeschenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<VorgangDTO> BelegLoeschenAsync(Guid bguid)
        => await DeleteAsync<VorgangDTO>($"Vorgang/DeleteBeleg/{bguid}", null);

    public async Task DeleteBelegWithPositionsAsync(Guid vorgangGuid, Guid belegGuid, bool unlockPredecessors)
        => await DeleteAsync($"Vorgang/DeleteBelegWithPositions/{vorgangGuid}/{belegGuid}?unlockPredecessors={unlockPredecessors}");

    /// <summary>
    /// Löscht Positionen samt AV-Daten und hängt ihre Nachfolger um. Die erste Guid ist die Position, die der Anwender löscht,
    /// die weiteren sind die im Dialog gewählten Vorgänger und Nachfolger. 409 bei ausgeschalteter automatischer Datenübernahme
    /// oder wenn die Positionsampel eine davon Rot zeigt.
    /// </summary>
    public async Task DeletePositionenAsync(Guid vorgangGuid, List<Guid> belegPositionGuids, bool unlockPredecessors)
        => await DeleteAsync($"Vorgang/DeletePositionen/{vorgangGuid}?unlockPredecessors={unlockPredecessors}&{string.Join("&", belegPositionGuids.Select(g => $"belegPositionGuids={g}"))}");
}

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
    /// Löscht die Position und die gewählten verknüpften Positionen (<paramref name="zielBelegPositionGuids"/>) samt AV-Daten und
    /// hängt ihre Nachfolger um. 409 bei ausgeschalteter automatischer Datenübernahme, archiviertem Vorgang, roter Positionsampel oder
    /// einer Position außerhalb der Kette, 403 bei einem fremden Vorgang.
    /// </summary>
    /// <remarks>
    /// Die Ziele stehen in der Query. IIS lässt dort 2048 Zeichen zu, das reicht für rund 30 Ziele.
    /// </remarks>
    public async Task DeletePositionenAsync(Guid vorgangGuid, Guid belegPositionGuid, List<Guid> zielBelegPositionGuids, bool unlockPredecessors)
        => await DeleteAsync($"Vorgang/DeletePositionen/{vorgangGuid}/{belegPositionGuid}?unlockPredecessors={unlockPredecessors}{string.Concat((zielBelegPositionGuids ?? []).Select(g => $"&zielBelegPositionGuids={g}"))}");
}

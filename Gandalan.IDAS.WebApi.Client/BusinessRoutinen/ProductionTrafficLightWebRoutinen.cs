using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Produktion.TrafficLight;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ProductionTrafficLightWebRoutinen : WebRoutinenBase
{
    public ProductionTrafficLightWebRoutinen(IWebApiConfig settings) : base(settings) { }

    /// <summary>
    /// Die Belege der angefragten Position stehen vorn.
    /// </summary>
    public async Task<List<BelegTrafficLightDTO>> GetForPositionChangeAsync(Guid vorgangGuid, Guid belegPositionGuid)
        => await GetAsync<List<BelegTrafficLightDTO>>($"ProductionTrafficLight/PositionChange/{vorgangGuid}/{belegPositionGuid}");

    /// <summary>
    /// Der Beleg, der gelöscht werden soll, steht an erster Stelle, auch ohne Positionen. Nur sein Status entscheidet, ob er
    /// gelöscht werden darf, die Nachfolger danach zeigen nur die Folgen.
    /// </summary>
    public async Task<List<BelegTrafficLightDTO>> GetForBelegDeletionAsync(Guid vorgangGuid, Guid belegGuid)
        => await GetAsync<List<BelegTrafficLightDTO>>($"ProductionTrafficLight/BelegDeletion/{vorgangGuid}/{belegGuid}");
}

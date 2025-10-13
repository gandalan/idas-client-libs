using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegPositionenWebRoutinen : WebRoutinenBase
{
    public BelegPositionenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<List<Guid>> SetBelegPositionGesperrtStatusAsync(bool gesperrtStatus, List<Guid> positionen)
        => await PutAsync<List<Guid>>($"BelegPositionGesperrtStatus/SetStatus/{gesperrtStatus}", positionen);

    public async Task<VorgangDTO> GetVorgangForFunctionAsync(Guid belegPositionGuid, long mandantId)
        => await GetAsync<VorgangDTO>($"BelegPositionen/GetVorgangForFunction?belegPositionGuid={belegPositionGuid}&mandantId={mandantId}");

    public async Task<List<BelegPositionDTO>> GetBelegPositionenFromGuidList(List<Guid> belegPositionGuidList)
        => await PostAsync<List<BelegPositionDTO>>($"BelegPositionen/GetByGuidList", belegPositionGuidList);
}

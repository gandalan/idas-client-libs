using Gandalan.IDAS.Client.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BelegPositionenWebRoutinen : WebRoutinenBase
    {
        public BelegPositionenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public void RunBelegPositionAVLogic(long mandantId, Guid belegPositionGuid)
        {
            Post("BelegPositionen/RunBelegPositionAVLogic?mandantId=" + mandantId + "&belegPositionGuid=" + belegPositionGuid, null);
        }

        public async Task RunBelegPositionAVLogicAsync(long mandantId, Guid belegPositionGuid)
        {
            await Task.Run(() => RunBelegPositionAVLogic(mandantId, belegPositionGuid));
        }

        public List<Guid> SetBelegPositionGesperrtStatus(bool gesperrtStatus, List<Guid> positionen)
        {
            if (Login())
            {
                return Put<List<Guid>>($"BelegPositionGesperrtStatus/SetStatus/{gesperrtStatus}", positionen);
            }
            return null;
        }

        public async Task<List<Guid>> SetBelegPositionGesperrtStatusAsync(bool gesperrtStatus, List<Guid> positionen)
        {
            if (Login())
            {
                return await PutAsync<List<Guid>>($"BelegPositionGesperrtStatus/SetStatus/{gesperrtStatus}", positionen);
            }
            return null;
        }
    }
}

using Gandalan.IDAS.Client.Contracts.Contracts;
using System;
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
    }
}

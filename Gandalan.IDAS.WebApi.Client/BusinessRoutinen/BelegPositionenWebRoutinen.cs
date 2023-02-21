using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
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
        
        public void UpdateBelegPositionAVData(long mandantId, Guid belegPositionGuid)
        {
            Post("BelegPositionen/UpdateBelegPositionAVData?mandantId=" + mandantId + "&belegPositionGuid=" + belegPositionGuid, null);
        }

        public async Task UpdateBelegPositionAVDataAsync(long mandantId, Guid belegPositionGuid)
        {
            await PostAsync("BelegPositionen/UpdateBelegPositionAVData?mandantId=" + mandantId + "&belegPositionGuid=" + belegPositionGuid, null);
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

        public string CalculateItems()
        {
            return Post("BelegPositionen/CalculateItems", null);
        }

        public VorgangDTO GetVorgangForFunction(Guid belegPositionGuid, long mandantId)
        {
            if (Login())
            {
                return Get<VorgangDTO>("BelegPositionen/GetVorgangForFunction?belegPositionGuid=" + belegPositionGuid.ToString() + "&mandantId=" + mandantId.ToString());
            }
            return null;
        }
    }
}

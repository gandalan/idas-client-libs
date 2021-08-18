using Gandalan.IDAS.Client.Contracts.Contracts;
using System;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BelegPositionenAVWebRoutinen : WebRoutinenBase
    {
        public BelegPositionenAVWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public string RunAVBerechnung(Guid id, long mandantId)
        {
            return Post("BelegPositionenAV/GetForWebJob/" + id + "?mandantId=" + mandantId, null);
        }

        public string CalculateItems()
        {
            return Post("BelegPositionenAV/CalculateItems", null);
        }
    }
}

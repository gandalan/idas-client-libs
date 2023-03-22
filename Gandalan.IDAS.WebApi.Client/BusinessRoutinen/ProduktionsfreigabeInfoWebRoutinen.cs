using Gandalan.IDAS.Client.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionsfreigabeInfoWebRoutinen : WebRoutinenBase
    {
        public ProduktionsfreigabeInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public Dictionary<Guid, DateTime> GetProduktionsfreigabeInfo(IList<Guid> belegGuids)
        {
            if (Login())
            {
                return Put<Dictionary<Guid, DateTime>>("ProduktionsfreigabeInfo", belegGuids);
            }
            return null;
        }

        public async Task<Dictionary<Guid, DateTime>> GetProduktionsfreigabeInfoAsync(IList<Guid> belegGuids)
        {
            return await Task.Run(() => GetProduktionsfreigabeInfo(belegGuids));
        }
    }
}

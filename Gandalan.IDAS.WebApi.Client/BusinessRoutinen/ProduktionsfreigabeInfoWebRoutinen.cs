using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionsfreigabeInfoWebRoutinen : WebRoutinenBase
    {
        public ProduktionsfreigabeInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<Dictionary<Guid, DateTime>> GetProduktionsfreigabeInfoAsync(IList<Guid> belegGuids)
            => await PutAsync<Dictionary<Guid, DateTime>>("ProduktionsfreigabeInfo", belegGuids);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IProduktionsfreigabeInfoService
    {
        Task<Dictionary<Guid, DateTime>> GetProduktionsfreigabeInfoAsync(IList<Guid> belegGuids);

        Dictionary<Guid, DateTime> GetProduktionsfreigabeInfo(IList<Guid> belegGuids);
    }
}

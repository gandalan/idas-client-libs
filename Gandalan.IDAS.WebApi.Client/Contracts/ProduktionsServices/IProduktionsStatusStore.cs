using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.Client.Contracts;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsStatusStore : IStore<ProduktionsStatusDTO>
    {
    }
}

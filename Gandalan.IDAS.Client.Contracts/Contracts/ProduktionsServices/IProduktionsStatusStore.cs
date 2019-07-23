using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsStatusStore
    {
        IList<ProduktionsStatusDTO> GetAll();
        ProduktionsStatusDTO Get(Guid positionsGuid);
        void Save(ProduktionsStatusDTO status);
        void Remove(Guid positionsGuid);
    }
}

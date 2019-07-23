using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVElementStore
    {
        bool HasAVData(Guid positionsGuid);

        BelegPositionAVDTO GetAVData(Guid positionsGuid);

        void SetAVData(BelegPositionAVDTO data);

        void CreateAVData(BelegPositionDTO position, string kunde, string kommission);

        IList<BelegPositionAVDTO> GetAll();

        IList<BelegPositionAVDTO> Get(Func<BelegPositionAVDTO, bool> include);

        void DeleteAVData(Guid positionsGuid);
    }
}

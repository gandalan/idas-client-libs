using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.ProduktionsServices
{
    public interface ISLKDatenGenerator
    {
        /// <summary>
        /// Erzeugt die SLK Datei zu einem BelegPostionAVDTO
        /// </summary>
        /// <param name="belegPositionAVDTO">avDTO</param>
        /// <returns></returns>
        Task CreateSLKFile(BelegPositionAVDTO belegPositionAVDTO);

        /// <summary>
        /// Erzeugt die SLK Dateien zu einer Liste von BelegPositionAVDTOs
        /// </summary>
        /// <param name="belegPositionAVDTOs">Liste von AVDTOs</param>
        /// <returns></returns>
        Task CreateSLKFiles(IList<BelegPositionAVDTO> belegPositionAVDTOs);
    }
}

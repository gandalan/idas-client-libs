using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.ProduktionsServices;

public interface ISLKDatenGenerator
{
    /// <summary>
    /// Erzeugt die SLK Datei zu einem BelegPostionAVDTO
    /// </summary>
    /// <param name="belegPositionAVDTO">avDTO</param>
    Task CreateSLKFile(BelegPositionAVDTO belegPositionAVDTO);

    /// <summary>
    /// Erzeugt die SLK Dateien zu einer Liste von BelegPositionAVDTOs
    /// </summary>
    /// <param name="belegPositionAVDTOs">Liste von AVDTOs</param>
    Task CreateSLKFiles(IList<BelegPositionAVDTO> belegPositionAVDTOs);
}
using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report
{
    public interface ISerienPacklisteAufbereitenService
    {
        Task<SerienPacklisteDataDTO> Aufbereiten(SerieDTO serie, IList<BelegPositionAVDTO> elemente);
        Task<SerienPacklisteDataDTO> Aufbereiten(VorgangDTO vorgang, IList<BelegPositionAVDTO> elemente);
        Task<SerienPacklisteDataDTO> getBySerie(SerieDTO serie, IList<BelegPositionAVDTO> elemente);
    }
}

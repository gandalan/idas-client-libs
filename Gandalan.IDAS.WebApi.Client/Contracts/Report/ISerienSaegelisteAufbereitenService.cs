using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report
{
    public interface ISerienSaegelisteAufbereitenService
    {
        Task<List<SerienSaegelisteDataDTO>> Aufbereiten(SerieDTO serie, IList<BelegPositionAVDTO> elemente);
        Task<List<SerienSaegelisteDataDTO>> Aufbereiten(VorgangDTO vorgang, IList<BelegPositionAVDTO> elemente);
        Task<List<SerienSaegelisteDataDTO>> getBySerie(SerieDTO serie, IList<BelegPositionAVDTO> elemente, IList<string> winkel, string titel);
        Task<List<SerienSaegelisteDataDTO>> getBySerie(SerieDTO serie, IList<BelegPositionAVDTO> elemente, IOrderedEnumerable<KeyValuePair<string, MaterialbedarfDTO>> orderedZuschnitte, IList<string> winkel, string titel);

    }
}

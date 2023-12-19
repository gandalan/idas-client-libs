using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Report;

public interface ISerienPacklistenEtikettenAufbereitenService
{
    public Task<List<EtikettDTO>> CreateEtiketten(SerieDTO serie, SerienPacklisteDataDTO packliste, IList<BelegPositionAVDTO> avDTOs = null);
}

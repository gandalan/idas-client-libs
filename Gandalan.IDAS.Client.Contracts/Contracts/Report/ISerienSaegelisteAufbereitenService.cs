using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report
{
    public interface ISerienSaegelisteAufbereitenService
    {
        Task<List<SerienSaegelisteDataDTO>> Aufbereiten(SerieDTO serie);
        Task<SerienSaegelisteDataDTO> getBySerie(SerieDTO serie, IList<BelegPositionAVDTO> elemente, string winkel);
    }
}

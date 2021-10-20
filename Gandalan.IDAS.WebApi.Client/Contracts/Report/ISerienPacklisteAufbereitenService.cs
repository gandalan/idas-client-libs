using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report
{
    public interface ISerienPacklisteAufbereitenService
    {
        Task<SerienPacklisteDataDTO> Aufbereiten(SerieDTO serie);
        Task<SerienPacklisteDataDTO> Aufbereiten(string vorgangsnummer, int year);
        Task<SerienPacklisteDataDTO> getBySerie(SerieDTO serie, IList<BelegPositionAVDTO> elemente);
    }
}

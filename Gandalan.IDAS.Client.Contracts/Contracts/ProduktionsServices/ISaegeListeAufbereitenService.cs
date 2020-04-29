using Gandalan.IDAS.Client.Contracts.Contracts.ReportData;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ISaegeListeAufbereitenService {
        Task<IEnumerable<IMaterialReportData>> SortAndGroup(string groupedProperty, IEnumerable<IMaterialReportDataListItem> items);
    }
}
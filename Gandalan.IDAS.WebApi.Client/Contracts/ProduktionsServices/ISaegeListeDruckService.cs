using Gandalan.IDAS.Client.Contracts.Contracts.ReportData;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ISaegeListeDruckService {
        Task Print(IEnumerable<IMaterialReportData> reports);
    }
}
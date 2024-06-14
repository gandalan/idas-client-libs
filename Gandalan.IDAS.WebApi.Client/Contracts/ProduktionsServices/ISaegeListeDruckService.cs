using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts.ReportData;

namespace Gandalan.Client.Contracts.ProduktionsServices;

public interface ISaegeListeDruckService
{
    Task Print(IEnumerable<IMaterialReportData> reports);
}
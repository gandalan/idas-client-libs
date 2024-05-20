using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.CSV;
public interface ICSVExport
{
    Task<bool> ExportCSV(IList<ICSVRecord> data, string path);
}

public interface ICSVRecord
{
    IList<PropertyInfo> GetExportProperties();
}

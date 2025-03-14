using System.Globalization;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class DataMigrationHistoryWebRoutinen : WebRoutinenBase
{
    public DataMigrationHistoryWebRoutinen(IWebApiConfig settings) : base(settings) { }

    public async Task<long> GetHistoryVersionAsync()
        => await GetAsync<long>("DataMigrationHistory");

    public async Task SetHistoryVersionAsync(long newVersion)
        => await PutAsync("DataMigrationHistory", newVersion.ToString(CultureInfo.InvariantCulture));
}
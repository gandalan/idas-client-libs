using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class DataMigrationHistoryWebRoutinen : WebRoutinenBase
    {
        public DataMigrationHistoryWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public long GetHistoryVersion()
        {
            if (Login())
                return Get<long>("DataMigrationHistory");
            throw new ApiException("Login fehlgeschlagen");
        }
        public string SetHistoryVersion(long newVersion)
        {
            if (Login())
                return Put("DataMigrationHistory", newVersion.ToString());
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task SetHistoryVersionAsync(long newVersion) => await Task.Run(() => SetHistoryVersion(newVersion));
        public async Task<long> GetHistoryVersionAsync() => await Task.Run(() => { return GetHistoryVersion(); });

    }
}

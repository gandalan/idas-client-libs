using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BackupWebRoutinen : WebRoutinenBase
    {
        public BackupWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<List<Guid>> GetVorgangGuidsAsync(string email, int year = 0, bool onlyBills = false)
        {
            return await GetAsync<List<Guid>>("Backup/GetVorgangGuids?email=" + Uri.EscapeDataString(email) + "&jahr=" + year + "&nurRechnungen=" + onlyBills, null);
        }

        public async Task<VorgangExtendedDTO> GetVorgangAsync(string email, Guid guid, bool onlyBills = false)
        {
            return await GetAsync<VorgangExtendedDTO>("Backup/GetVorgang?email=" + Uri.EscapeDataString(email) + "&nurRechnungen=" + onlyBills + "&guid=" + guid);
        }

        public async Task RequestBackup(string email, bool onlyBills, int year)
        {
            await PostAsync("Backup/RequestBackup?email=" + Uri.EscapeDataString(email) + "&nurRechnungen=" + onlyBills + "&jahr=" + year, null);
        }
    }
}

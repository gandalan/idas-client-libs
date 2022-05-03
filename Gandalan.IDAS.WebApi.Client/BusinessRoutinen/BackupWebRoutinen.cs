using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BackupWebRoutinen : WebRoutinenBase
    {
        public BackupWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public List<Guid> GetVorgangGuids(string email, int year = 0, bool onlyBills = false)
        {
            return Get<List<Guid>>("Backup/GetVorgangGuids?email=" + System.Uri.EscapeDataString(email) + "&jahr=" + year + "&nurRechnungen=" + onlyBills, null);
        }

        public VorgangExtendedDTO GetVorgang(string email, Guid guid, bool onlyBills = false)
        {
            return Get<VorgangExtendedDTO>("Backup/GetVorgang?email=" + System.Uri.EscapeDataString(email) + "&nurRechnungen=" + onlyBills + "&guid=" + guid);
        }

        public void RequestBackup(string email, bool onlyBills, int year)
        {
            Post("Backup/RequestBackup?email=" + System.Uri.EscapeDataString(email) + "&nurRechnungen=" + onlyBills + "&jahr=" + year, null);
        }
    }
}

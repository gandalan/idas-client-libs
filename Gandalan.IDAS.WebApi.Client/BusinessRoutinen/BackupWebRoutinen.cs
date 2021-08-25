using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BackupWebRoutinen : WebRoutinenBase
    {
        public BackupWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public void Run(string email, bool onlyBills, int year)
        {
            Post("Backup/Post?email=" + email + "&nurRechnungen=" + onlyBills + "&jahr=" + year, null);
        }

        public void RequestBackup(string email, bool onlyBills, int year)
        {
            Post("Backup/RequestBackup?email=" + email + "&nurRechnungen=" + onlyBills + "&jahr=" + year, null);
        }
    }
}

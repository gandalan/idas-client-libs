namespace Gandalan.IDAS.WebApi.Client.Backup
{
    public class BackupRequest
    {
        public string Email { get; set; }
        public bool OnlyBills { get; set; }
        public int Year { get; set; }
    }
}

using System.Collections.Generic;

namespace Gandalan.Client.Contracts.DataServices
{
    /// <summary>
    /// Implementiert einen Service zum Versenden von E-Mails, optional mit Anhang
    /// </summary>
    public interface IMailService
    {
        void SendMail(string from, string to, string subject, string content, List<string> attachments = null);
    }
}

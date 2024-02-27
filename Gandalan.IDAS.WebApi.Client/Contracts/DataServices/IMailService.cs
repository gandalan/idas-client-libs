using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    /// <summary>
    /// Implementiert einen Service zum Versenden von E-Mails, optional mit Anhang
    /// </summary>
    public interface IMailService
    {
        Task SendMailAsync(string from, string to, string subject, string content, List<string> attachments = null);
    }
}

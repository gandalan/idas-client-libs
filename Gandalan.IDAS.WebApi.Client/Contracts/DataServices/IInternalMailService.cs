using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    /// <summary>
    /// Implementiert einen Service zum Versenden von internen E-Mails (nicht kundenbezogen, also z.B. Fehlerberichte), optional mit Anhang
    /// </summary>
    public interface IInternalMailService
    {
        Task SendMailAsync(string from, string to, string subject, string content, List<string> attachments = null);
    }
}

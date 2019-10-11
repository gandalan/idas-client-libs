using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IMailService
    {
        void SendMail(string from, string to, string content, List<string> attachments = null);
    }
}

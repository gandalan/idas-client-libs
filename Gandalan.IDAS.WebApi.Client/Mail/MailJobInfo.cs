using System;

namespace Gandalan.IDAS.WebApi.Client.Mail;

public class MailJobInfo
{
    public Guid JobGuid { get; set; }
    public string[] ToAddresses { get; set; }
    public string[] CCAddresses { get; set; }
    public string ReplyToAddress { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public Guid BelegGuid { get; set; }
}
using System;
using System.Collections.Generic;
using Gandalan.IDAS.Jobs.Contracts;
using Gandalan.IDAS.WebApi.Client.Mail;

namespace Gandalan.IDAS.WebApi.Client.Printing;

public class BelegDruckJobData : IBelegPrintJobData
{
    public JobArt Job { get; set; }
    public Guid BelegGuid { get; set; }
    public List<string> VorgangNummern { get; set; }
    public string Email { get; set; }
    public string EmailContent { get; set; }
    public long MandantId { get; set; }
    public Guid AppToken { get; set; }
    public string FileFormat { get; set; }
    public MailJobInfo MailJobInfo { get; set; }
    public string OutputFileName { get; set; }
    public bool ReportsProgress { get; set; }
    public int ProgressPercent { get; set; }
    public bool HasFinished { get; set; }
    public byte[] Result { get; set; }
    public bool IncludeBriefkopf { get; set; }
    public bool SavePDF { get; set; }
    public string DefaultPrinter { get; set; }
    public int Copies { get; set; }
    public Guid VorgangGuid { get; set; }
}

public enum JobArt
{
    Unbekannt = 0,
    Print = 1,
    Backup = 2,
    Mail = 3,
}

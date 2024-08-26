using System;

namespace Gandalan.IDAS.Jobs.Contracts;

public interface IDataPrintJob : IBackgroundJob<IDataPrintJobData>
{
    bool CanHandle(Guid reportGuid, long mandantId);
}

public interface IDataPrintJobData : IJobData
{
    Guid PrintGuid { get; set; }
    object Data { get; set; }
    Guid ReportGuid { get; set; }
    string FileFormat { get; set; }
    string ResultAsBase64String { get; set; }
    string DruckerName { get; set; }
    bool AdvancedPrint { get; set; }
    long MandantId { get; set; }
    int Copies { get; set; }
}


public class DataPrintJobData : IDataPrintJobData
{
    public Guid PrintGuid { get; set; } = Guid.NewGuid();
    public object Data { get; set; }
    public Guid ReportGuid { get; set; }
    public bool ReportsProgress { get; set; } = true;
    public int ProgressPercent { get; set; }
    public bool HasFinished { get; set; }
    public string FileFormat { get; set; } = "XPS";
    public string ResultAsBase64String { get; set; }
    public string DruckerName { get; set; }
    public bool AdvancedPrint { get; set; }
    public long MandantId { get; set; }
    public int Copies { get; set; }

    public DataPrintJobData(object daten, Guid reportGuid, int copies = 1)
    {
        Data = daten;
        ReportGuid = reportGuid;
        Copies = copies;
    }
}
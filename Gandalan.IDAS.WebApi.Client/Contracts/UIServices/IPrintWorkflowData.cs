using System;

namespace Gandalan.Client.Contracts.UIServices;

public interface IPrintWorkflowData
{
    Guid ReportGuid { get; set; }
    object Daten { get; set; }
    bool IsList { get; set; }
    bool PrintSelectedData { get; set; }
    bool ShowPrintSelectedData { get; set; }
    string PrinterName { get; set; }
    int Copies { get; set; }
}

public class PrintWorkflowData : IPrintWorkflowData
{
    public Guid ReportGuid { get; set; }
    public object Daten { get; set; }
    public bool IsList { get; set; }
    public bool PrintSelectedData { get; set; }
    public bool ShowPrintSelectedData { get; set; } = true;
    public string PrinterName { get; set; }
    public int Copies { get; set; }
}
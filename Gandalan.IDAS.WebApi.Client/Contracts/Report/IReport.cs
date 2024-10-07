using System;
using System.IO;
using System.Threading.Tasks;
using Gandalan.Client.Contracts.AppServices;
using Gandalan.IDAS.WebApi.Client.Contracts.Report;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Report;

public abstract class IReport
{
    public abstract Guid Guid { get; }
    protected readonly IApplicationConfig AppConfig;
    protected abstract string ReportFolderName { get; set; }

    public abstract string Name { get; set; }
    public abstract ReportTypeDTO ReportType { get; set; }
    public abstract ReportAction[] AllowedActions { get; }
    public abstract ReportCapability[] Capabilities { get; }

    public abstract bool CanHandle(object data = null);

    public IReport(IApplicationConfig appConfig)
    {
        AppConfig = appConfig;
    }

    public virtual string GetWorkingDir(ReportAction action)
    {
        var baseDir = action == ReportAction.Design
            ? AppConfig.StandardReportsDevDir
            : AppConfig.StandardReportsDir;
        return Path.Combine(baseDir, ReportFolderName);

    }

    public virtual string GetDataDir(ReportAction action)
    {
        return action == ReportAction.Design
         ? Path.Combine(GetWorkingDir(action), "public", "data")
         : Path.Combine(GetWorkingDir(action), "data");
    }

    public virtual async Task InitializeFolders(ReportAction action, bool copyCommomHtmlData = true)
    {
        var workingDir = GetWorkingDir(action);
        var dataDir = GetDataDir(action);

        if (!Directory.Exists(workingDir))
        {
            throw new InvalidOperationException($"Reportverzeichnis '{workingDir}' nicht gefunden.");
        }

        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        if (!copyCommomHtmlData)
        {
            return;
        }

        var sourceDir = Path.Combine(AppConfig.DataDir, "HTMLReportCommon");
        if (Directory.Exists(sourceDir))
        {
            foreach (var document in new DirectoryInfo(sourceDir).GetFiles())
            {
                File.Copy(document.FullName, $"{workingDir}/{document.Name}", true);
            }
        }
        await Task.CompletedTask;
    }

    public abstract Task Execute(ReportExecuteSettings reportSettings);
}

public abstract class IReport<T> : IReport where T : class
{
    public IReport(IApplicationConfig appConfig) : base(appConfig)
    {
    }

    public T Data { get; set; }
    public abstract Task Initialize(T data);
}

public enum ReportAction
{
    Cancel = 0,
    Print = 1,
    Preview = 3,
    Export = 4,
    Design = 99,
}

public enum ReportCapability
{
    Watermark = 1,
}

public class ReportExecuteSettings
{
    public string ReportName { get; set; }
    public ReportAction ReportAction { get; set; }
    public string PrinterName { get; set; }

    /// <summary>
    /// Page width in mm
    /// </summary>
    public double PageWidth { get; set; } = 210;

    /// <summary>
    /// Page height in mm
    /// </summary>
    public double PageHeight { get; set; } = 297;

    public string FileName { get; set; }
    public int Copies { get; set; } = 1;
    public string Watermark { get; set; }

    public static ReportExecuteSettings FromReportAuswahlResult(IReportAuswahlResult result)
    {
        return new ReportExecuteSettings
        {
            ReportAction = result.Action,
            PrinterName = result.PrinterName,
            FileName = result.FileName,
            Copies = result.Copies,
            Watermark = result.Watermark
        };
    }
}

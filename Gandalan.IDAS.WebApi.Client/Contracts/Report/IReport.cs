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
    public virtual bool IsLandscape => false;

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
    /// <summary>Das ausgewählte Etikettenlayout bleibt nach Übernahme seiner Druckparameter als Reportkonfiguration erhalten.</summary>
    public IEtikettenPrintLayoutSettings LayoutSettings { get; set; }

    public ReportAction ReportAction { get; set; }
    public string PrinterName { get; set; }
    public string PaperSourceName { get; set; }

    /// <summary>
    /// Page width in mm
    /// </summary>
    public double MediaPageWidthMm { get; set; } = 210;

    /// <summary>
    /// Page height in mm
    /// </summary>
    public double MediaPageHeightMm { get; set; } = 297;
    public bool IsLandscape { get; set; }

    public string FileName { get; set; }
    public int Copies { get; set; } = 1;
    public string Watermark { get; set; }


    public static ReportExecuteSettings FromReportAuswahlResult(IReportAuswahlResult result)
    {
        var settings = new ReportExecuteSettings
        {
            ReportAction = result.Action,
            PrinterName = result.PrinterName,
            PaperSourceName = result.PaperSourceName,
            FileName = result.FileName,
            Copies = result.Copies,
            Watermark = result.Watermark,
            PrinterPaperName = result.PrinterPaperName,
            ShowSerienName = result.ShowSerienName,
            PrinterPaperWidthMm = result.PrinterPaperWidthMm,
            PrinterPaperHeightMm = result.PrinterPaperHeightMm,
            PrinterDpi = result.PrinterDpi,
            IsLandscape = result.Report.IsLandscape,
        };
        return result.LayoutSettings == null ? settings : settings.WithEtikettenLayout(result.LayoutSettings);
    }

    /// <summary>
    /// Übernimmt das ausgewählte Etikettenlayout in die Drucker- und Seiteneinstellungen und hält es als Reportkonfiguration fest.
    /// Während der Vorbereitung aufrufen; die Ausführung verwendet die vorbereiteten Werte ohne erneute Übernahme des Layouts.
    /// Die Reportausrichtung und die übrigen Ausführungsoptionen bleiben unverändert.
    /// </summary>
    public ReportExecuteSettings WithEtikettenLayout(IEtikettenPrintLayoutSettings layout)
    {
        LayoutSettings = layout ?? throw new ArgumentNullException(nameof(layout));
        PrinterName = layout.DruckerName;
        PaperSourceName = layout.PaperSourceName;
        PrinterDpi = layout.Dpi;
        ContentOffsetXMm = layout.ContentOffsetXMm;
        ContentOffsetYMm = layout.ContentOffsetYMm;
        if (layout.Papierformat is not { WidthMM: > 0, HeightMM: > 0 } paper) return this;
        PrinterPaperName = paper.Name;
        PrinterPaperHeightMm = paper.HeightMM;
        PrinterPaperWidthMm = paper.WidthMM;
        MediaPageHeightMm = paper.HeightMM;
        MediaPageWidthMm = paper.WidthMM;
        return this;
    }


    public bool ShowSerienName { get; set; }
    public double ContentOffsetXMm { get; set; }
    public double ContentOffsetYMm { get; set; }
    public string PrinterPaperName { get; set; }
    public double PrinterPaperWidthMm { get; set; }
    public double PrinterPaperHeightMm { get; set; }
    public int PrinterDpi { get; set; }
}

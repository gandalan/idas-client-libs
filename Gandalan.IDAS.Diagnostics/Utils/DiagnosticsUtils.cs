using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Gandalan.IDAS.Logging;

namespace Gandalan.IDAS.Diagnostics.Utils;

/// <summary>
/// Helper Klasse zum Generieren von Fehlerberichten
/// </summary>
public class DiagnosticsUtils
{
    /// <summary>
    /// Erstellt eine Diagnose Zip File im Logging Pfad
    /// </summary>
    /// <returns></returns>
    public static async Task<string> CreateDiagnoseZipFile()
    {
        var logFile = Logger.GetInstance().LogDateiName;
        var zipFile = Path.Combine(Logger.LogDateiPfad, $"Diagnose-{DateTime.UtcNow.Ticks}.zip");

        if (!File.Exists(logFile))
        {
            return zipFile;
        }

        using var fileStream = new FileStream(zipFile, FileMode.CreateNew);
        using var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true);
        File.Copy(logFile, $"{logFile}.tmp", true);
        var zipArchiveEntry = archive.CreateEntry(Path.GetFileName(logFile), CompressionLevel.Fastest);
        var data = File.ReadAllBytes($"{logFile}.tmp");
        using var zipStream = zipArchiveEntry.Open();
        await zipStream.WriteAsync(data, 0, data.Length);

        return zipFile;
    }

    /// <summary>
    /// Zieht die Windowsversion auf der Registry
    /// </summary>
    /// <returns>Die Windowsversion z.B. "Windows 10 Pro 22H2 10.0.19045.6216"</returns>
    public static string GetOSVersion()
    {
        try
        {
            using var regEntry = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion", false);
            if (regEntry == null)
            {
                return Environment.OSVersion.ToString();
            }

            var productName = regEntry.TryGetStringValue("ProductName");
            var displayVersion = regEntry.TryGetStringValue("DisplayVersion");
            var buildNumber = regEntry.TryGetStringValue("CurrentBuild");

            //productName contains Windows 10 for Windows 11 so we need to manually check the buildnumber
            if (int.TryParse(buildNumber, out var buildNumberInt) && buildNumberInt >= 22000)
            {
                productName = productName?.Replace(" 10", " 11");
            }

            var lcuVer = regEntry.TryGetStringValue("LCUVer");
            //lcuVer only exists since Windows 11 and newer Windows 10 versions
            if (string.IsNullOrEmpty(lcuVer))
            {
                var majorNumber = regEntry.TryGetStringValue("CurrentMajorVersionNumber");
                var minorNumber = regEntry.TryGetStringValue("CurrentMinorVersionNumber");
                var ubr = regEntry.TryGetStringValue("UBR");
                lcuVer = $"{majorNumber}.{minorNumber}.{buildNumber}.{ubr}";
            }

            return $"{productName} {displayVersion} {lcuVer}";
        }
        catch (Exception e)
        {
            L.Fehler(e);
        }

        return Environment.OSVersion.ToString();
    }
}

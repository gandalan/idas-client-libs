using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Gandalan.IDAS.Logging.Contracts;

namespace Gandalan.IDAS.Logging;

public delegate void LogStringAddedDelegate(string logStr);

public class Logger : ILogger
{
    private static Logger _logger;
    private readonly object _lock = new();
    private TextWriterTraceListener _traceListener;

    public Dictionary<LogContext, LogLevel> LogLevels { get; set; }
    public event LogStringAddedDelegate OnLogStringAdded;

    public static string LogDateiPfad { get; private set; }
    public string LogDateiName { get; private set; }

    public Logger()
    {
        LogLevels = [];
        SetLogDateiPfad();
    }

    public void SetLogDateiPfad(string pfad = null)
    {
        var datum = DateTime.UtcNow.Date.ToString("yyyy-MM-dd");
        var app = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location ?? "WebApi");
        var user = Environment.UserName;

        try
        {
            LogDateiPfad = pfad ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Gandalan", app, "Logs");
            LogDateiName = Path.Combine(LogDateiPfad, $"{user}_{datum}.log");
            if (!Directory.Exists(LogDateiPfad))
            {
                Directory.CreateDirectory(LogDateiPfad);
            }

            lock (_lock)
            {
                _traceListener = new TextWriterTraceListener(LogDateiName);
            }

            LogConsoleDebug($"Logfile: {LogDateiName}");
        }
        catch (Exception ex)
        {
            LogConsoleDebug($"Logging in Datei nicht möglich: {ex}");
        }
    }

    public static Logger GetInstance()
    {
        return _logger ??= new Logger();
    }

    public void Log(string message, LogLevel level = LogLevel.Diagnose, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
    {
        if (LogLevels.TryGetValue(context, out var logLevelContext) &&
            level > logLevelContext)
        {
            return;
        }

        // Log-Eintrag formatieren
        const string timeFormat = "HH:mm:ss";
        var log = $"{context,-15} {level,-8} {DateTime.Now.ToString(timeFormat)} ";
        if (sender != null)
        {
#if DEBUG
            log += $"{sender,-16} ";
#else
            log += $"{sender.PadRight(16).Substring(0, 15)} ";
#endif
        }
        else
        {
            log += new string(' ', 16);
        }

        if (!string.IsNullOrEmpty(message))
        {
            log += message;
        }

        // Ausgeben in Logfile
        if (_traceListener != null)
        {
            lock (_lock)
            {
                _traceListener.WriteLine(log);
                _traceListener.Flush();
            }
        }

        // Event-Abonnenten informieren und/oder Debug-Ausgabe
        OnLogStringAdded?.Invoke(log);

        // Debug-Console ausgeben
        LogConsoleDebug(log);
    }

    /// <summary>
    /// Write to Console, Debug and Trace output. Does not write anything to file.
    /// </summary>
    /// <param name="message">Message to print</param>
    public static void LogConsoleDebug(string message)
    {
        Debug.WriteLine(message);
        Console.WriteLine(message);
        Trace.WriteLine(message);
    }
}

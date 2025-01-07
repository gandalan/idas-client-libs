using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Gandalan.IDAS.Logging.Contracts;

namespace Gandalan.IDAS.Logging;

/// <summary>
/// Delegate that defines the method signature for handling log string additions.
/// It is used to notify subscribers whenever a new log string is added.
/// </summary>
/// <param name="logStr">The log string that has been added.</param>
public delegate void LogStringAddedDelegate(string logStr);

/// <summary>
/// Provides functionality for logging messages to a file, console, and debug output.
/// </summary>
public class Logger : ILogger
{
    private static Logger _logger;
    private readonly object _lock = new();
    private TextWriterTraceListener _traceListener;

    /// <summary>
    /// Gets or sets the log levels configured for specific logging contexts.
    /// Each context can have its own log level to control the verbosity of logging.
    /// </summary>
    public Dictionary<LogContext, LogLevel> LogLevels { get; set; }

    /// <summary>
    /// Event triggered when a log entry is added. Allows external systems to subscribe and act upon log entries.
    /// </summary>
    public event LogStringAddedDelegate OnLogStringAdded;

    /// <summary>
    /// Gets the path to the directory where log files are stored.
    /// </summary>
    public static string LogDateiPfad { get; private set; }

    /// <summary>
    /// Gets the full path of the current log file, including the file name.
    /// </summary>
    public string LogDateiName { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Logger"/> class.
    /// Sets the default log file path and initializes the log levels.
    /// </summary>
    public Logger()
    {
        LogLevels = [];
        SetLogDateiPfad();
    }

    /// <summary>
    /// Sets the log file path and file name. Creates the directory if it does not exist.
    /// </summary>
    /// <param name="pfad">The custom path for the log file. If null, a default path is used.</param>
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

    /// <summary>
    /// Gets the singleton instance of the <see cref="Logger"/> class.
    /// If an instance has not been created, it will create one.
    /// </summary>
    /// <returns>The singleton instance of the <see cref="Logger"/> class.</returns>
    public static Logger GetInstance()
    {
        return _logger ??= new Logger();
    }

    /// <summary>
    /// Logs a message to the log file, console, and triggers the <see cref="OnLogStringAdded"/> event.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="level">The log level indicating the severity of the log.</param>
    /// <param name="context">The context in which the log is being made, allowing different contexts to have different log levels.</param>
    /// <param name="sender">The name of the caller method, automatically populated using the <see cref="CallerMemberNameAttribute"/> attribute.</param>
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

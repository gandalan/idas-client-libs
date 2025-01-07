using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gandalan.IDAS.Logging.Contracts;

/// <summary>
/// Defines the contract for a logger.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Sets the path where the log file will be stored.
    /// If no path is provided, a default location will be used.
    /// </summary>
    /// <param name="pfad">The custom path to store the log file. If null, a default path will be used.</param>
    void SetLogDateiPfad(string pfad = null);

    /// <summary>
    /// Logs a message with a specified log level and context.
    /// The log is recorded in the log file and other outputs (console, debug).
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="level">The level of the log entry (default is Diagnose).</param>
    /// <param name="context">The context of the log entry (default is Allgemein).</param>
    /// <param name="sender">The name of the method that is calling the log (optional, automatically filled by the compiler).</param>
    void Log(string message, LogLevel level = LogLevel.Diagnose, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);

    /// <summary>
    /// Gets or sets the log levels configured for specific logging contexts.
    /// </summary>
    Dictionary<LogContext, LogLevel> LogLevels { get; set; }

    /// <summary>
    /// Occurs when a log string is added. Subscribers can use this event to process or display log messages.
    /// </summary>
    event LogStringAddedDelegate OnLogStringAdded;
}

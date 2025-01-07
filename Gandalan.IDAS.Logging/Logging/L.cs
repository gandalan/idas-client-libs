using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gandalan.IDAS.Logging;

/// <summary>
/// Provides static methods for logging messages at different log levels (e.g., Fehler, Immer, Warnung, Info, Diagnose).
/// These methods call the corresponding logging methods in the <see cref="Logger"/> class.
/// </summary>
public class L
{
    /// <summary>
    /// Logs a message with the "Fehler" log level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The context of the log entry (default is Allgemein).</param>
    /// <param name="sender">The name of the method that is calling the log (optional, automatically filled by the compiler).</param>
    public static void Fehler(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
    {
        Logger.GetInstance().Log(message, LogLevel.Fehler, context, sender);
    }

    /// <summary>
    /// Logs an exception and its message with the "Fehler" log level.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    /// <param name="message">Additional message to log alongside the exception.</param>
    /// <param name="context">The context of the log entry (default is Allgemein).</param>
    /// <param name="sender">The name of the method that is calling the log (optional, automatically filled by the compiler).</param>
    public static void Fehler(Exception ex, string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
    {
        Fehler($"{message}{Environment.NewLine}{DetailedException(ex)}", context, sender);
    }

    /// <summary>
    /// Logs an exception with the "Fehler" log level.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    /// <param name="context">The context of the log entry (default is Allgemein).</param>
    /// <param name="sender">The name of the method that is calling the log (optional, automatically filled by the compiler).</param>
    public static void Fehler(Exception ex, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
    {
        Fehler($"{DetailedException(ex)}", context, sender);
    }

    /// <summary>
    /// Logs a message with the "Immer" log level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The context of the log entry (default is Allgemein).</param>
    /// <param name="sender">The name of the method that is calling the log (optional, automatically filled by the compiler).</param>
    public static void Immer(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
    {
        Logger.GetInstance().Log(message, LogLevel.Immer, context, sender);
    }

    /// <summary>
    /// Logs a message with the "Warnung" log level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The context of the log entry (default is Allgemein).</param>
    /// <param name="sender">The name of the method that is calling the log (optional, automatically filled by the compiler).</param>
    public static void Warnung(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
    {
        Logger.GetInstance().Log(message, LogLevel.Warnung, context, sender);
    }

    /// <summary>
    /// Logs a message with the "Info" log level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The context of the log entry (default is Allgemein).</param>
    /// <param name="sender">The name of the method that is calling the log (optional, automatically filled by the compiler).</param>
    public static void Info(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
    {
        Logger.GetInstance().Log(message, LogLevel.Info, context, sender);
    }

    /// <summary>
    /// Logs a message with the "Diagnose" log level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="context">The context of the log entry (default is Allgemein).</param>
    /// <param name="sender">The name of the method that is calling the log (optional, automatically filled by the compiler).</param>
    public static void Diagnose(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
    {
        Logger.GetInstance().Log(message, LogLevel.Diagnose, context, sender);
    }

    /// <summary>
    /// Return string with detailed exception - data from RESTRoutinen.AddInfoToException.
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <returns>String with Data and exception</returns>
    public static string DetailedException(Exception ex)
    {
        // Use default exception formatting
        var exString = $"{ex}";
        if (ex.Data.Count > 0)
        {
            var dataDetails = new StringBuilder();
            foreach (DictionaryEntry entry in ex.Data)
            {
                dataDetails.Append($"{entry.Key}: {entry.Value}{Environment.NewLine}");
            }

            // Append the data details to the exception string
            exString = $"{dataDetails}{exString}";
        }

        if (ex.InnerException == null)
        {
            return exString;
        }

        // Recursively call DetailedException for inner exceptions
        var innerExceptionDetails = DetailedException(ex.InnerException);
        exString = $"Inner Exception Data:{Environment.NewLine}{innerExceptionDetails}{Environment.NewLine}Exception Data:{Environment.NewLine}{exString}";

        return exString;
    }
}

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gandalan.IDAS.Logging
{
    public class L
    {
        public static void Fehler(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Logger.GetInstance().Log(message, LogLevel.Fehler, context, sender);
        }

        public static void Fehler(Exception ex, string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Fehler($"{message}{Environment.NewLine}{DetailedException(ex)}", context, sender);
        }

        public static void Fehler(Exception ex, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Fehler($"{DetailedException(ex)}", context, sender);
        }

        public static void Immer(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Logger.GetInstance().Log(message, LogLevel.Immer, context, sender);
        }

        public static void Warnung(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Logger.GetInstance().Log(message, LogLevel.Warnung, context, sender);
        }

        public static void Info(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Logger.GetInstance().Log(message, LogLevel.Info, context, sender);
        }

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
            exString = $"Inner Exception Data:{innerExceptionDetails}{Environment.NewLine}Exception Data:{Environment.NewLine}{exString}";

            return exString;
        }
    }
}

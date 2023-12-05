using System;
using System.Runtime.CompilerServices;

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
            Fehler($"{message}{Environment.NewLine}{DetailedStringException(ex)}", context, sender);
        }

        public static void Fehler(Exception ex, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Fehler($"{DetailedStringException(ex)}", context, sender);
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
        private static string DetailedStringException(Exception ex)
        {
            // Use default exception formatting
            var exString = $"{ex}";
            if (ex.Data.Contains("URL") && ex.Data.Contains("CallMethod") && ex.Data.Contains("StatusCode"))
            {
                var newLine = Environment.NewLine;
                object response = null;
                if (ex.Data.Contains("Response"))
                {
                    response = $"{newLine}Response: {ex.Data["Response"]}";
                }

                exString = $"URL: {ex.Data["URL"]}{newLine}CallMethod: {ex.Data["CallMethod"]}{newLine}StatusCode: {ex.Data["StatusCode"]}{response}{newLine}{ex}";
            }

            return exString;
        }
    }
}

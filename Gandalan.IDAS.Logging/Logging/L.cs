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
            Fehler($"{message} {ex}", context, sender);
        }

        public static void Fehler(Exception ex, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Fehler($"{ex}", context, sender);
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
    }
}

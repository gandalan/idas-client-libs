using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            Fehler($"{message} {ex.GetType().FullName}: {ex.Message}", context, sender);
            if (ex is AggregateException)
            {
                foreach (var e in (ex as AggregateException).InnerExceptions)
                {
                    Fehler(e, message, context, sender);
                }
            }
        }

        public static void Fehler(Exception ex, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            Fehler($"{ex.GetType().FullName}: {ex.Message}", context, sender);
            if (ex is AggregateException)
            {
                foreach (var e in (ex as AggregateException).InnerExceptions)
                {
                    Fehler(e, context, sender);
                }
            }
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

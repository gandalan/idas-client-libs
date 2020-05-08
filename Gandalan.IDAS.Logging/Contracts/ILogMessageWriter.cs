using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Logging;

namespace Gandalan.IDAS.Logging.Contracts
{
    public interface ILogMessageWriter
    {
        void Fehler(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);
        void Fehler(Exception ex, string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);
        void Fehler(Exception ex, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);
        void Immer(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);
        void Warnung(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);
        void Info(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);
        void Diagnose(string message, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);
    }
}

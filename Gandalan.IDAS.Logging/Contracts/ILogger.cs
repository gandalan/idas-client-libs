using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Logging;

namespace Gandalan.IDAS.Logging.Contracts
{
    public interface ILogger
    {
        void SetLogDateiPfad(string pfad = null);

        void Log(string message, LogLevel level = LogLevel.Diagnose, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null);

        Dictionary<LogContext, LogLevel> LogLevels { get; set; }
        event LogStringAddedDelegate OnLogStringAdded;
    }
}

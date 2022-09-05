using Gandalan.IDAS.Logging.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Gandalan.IDAS.Logging
{
    public delegate void LogStringAddedDelegate(string logStr);

    public class Logger : ILogger
    {
        private static Logger _logger;
        private object _lock = new Object();
        private System.Diagnostics.TextWriterTraceListener _traceListener;

        public Dictionary<LogContext, LogLevel> LogLevels { get; set; }
        public event LogStringAddedDelegate OnLogStringAdded;

        public static string LogDateiPfad { get; private set; }
        public string LogDateiName { get; private set; }

        public Logger()
        {
            LogLevels = new Dictionary<LogContext, Logging.LogLevel>();
            SetLogDateiPfad();
        }

        public void SetLogDateiPfad(string pfad = null)
        {
            string datum = DateTime.Today.ToString("dd-MM-yyy");
            string app = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.CodeBase ?? "WebApi");
            string user = Environment.UserName;

            try
            {
                LogDateiPfad = pfad ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Gandalan", app, "Logs");
                LogDateiName = Path.Combine(LogDateiPfad, user + "_" + datum + ".log");
                if (!Directory.Exists(LogDateiPfad)) Directory.CreateDirectory(LogDateiPfad);
                _traceListener = new TextWriterTraceListener(LogDateiName);
                Debug.WriteLine($"Logfile: {LogDateiName}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Logging in Datei nicht möglich: {ex.Message}");
            }
        }

        public static Logger GetInstance()
        {
            return _logger ?? (_logger = new Logger());
        }

        public void Log(string message, LogLevel level = LogLevel.Diagnose, LogContext context = LogContext.Allgemein, [CallerMemberName] string sender = null)
        {
            if (LogLevels.ContainsKey(context) && level > LogLevels[context])
                return;

            // Log-Eintrag formatieren
            string log = context.ToString().PadRight(15) + " " + level.ToString().PadRight(8) + " " + DateTime.Now.ToShortTimeString() + " ";
            if (sender != null)
                log += sender.PadRight(16).Substring(0, 15) + " ";
            else
                log += new string(' ', 16);
            if (!string.IsNullOrEmpty(message))
                log += message;

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
            Debug.WriteLine(log);

            Console.WriteLine(log);
        }
    }
}

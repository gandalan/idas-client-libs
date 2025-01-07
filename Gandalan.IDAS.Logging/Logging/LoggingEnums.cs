namespace Gandalan.IDAS.Logging;

/// <summary>
/// Defines the logging levels used to specify the severity of log messages.
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// Always log this level, regardless of configuration.
    /// </summary>
    Immer = 0,

    /// <summary>
    /// Indicates a critical error.
    /// </summary>
    Fehler = 1,

    /// <summary>
    /// Indicates a warning.
    /// </summary>
    Warnung = 2,

    /// <summary>
    /// Provides informational messages.
    /// </summary>
    Info = 3,

    /// <summary>
    /// Used for diagnostic or verbose logging.
    /// </summary>
    Diagnose = 4,
}

/// <summary>
/// Defines the logging contexts used to categorize log messages.
/// </summary>
public enum LogContext
{
    /// <summary>
    /// General context.
    /// </summary>
    Allgemein = 0,

    /// <summary>
    /// Context related to Belegblatt.
    /// </summary>
    Belegblatt = 1,

    /// <summary>
    /// Context related to Belegposition.
    /// </summary>
    Belegposition = 2,

    /// <summary>
    /// Context related to AV.
    /// </summary>
    AV = 3,

    /// <summary>
    /// Context related to SLK.
    /// </summary>
    SLK = 4,

    /// <summary>
    /// Context related to UniDEx.
    /// </summary>
    UniDEx = 5,

    /// <summary>
    /// Context related to addresses.
    /// </summary>
    Adressen = 6,

    /// <summary>
    /// Context related to warehouse or inventory management.
    /// </summary>
    Lager = 7,

    /// <summary>
    /// Context related to statistical data or operations.
    /// </summary>
    Statistik = 8,

    /// <summary>
    /// Context related to rendering processes.
    /// </summary>
    Rendering = 9,

    /// <summary>
    /// Context related to licensing.
    /// </summary>
    Lizenz = 10,

    /// <summary>
    /// Context related to scripting operations.
    /// </summary>
    Scripting = 11,

    /// <summary>
    /// Context related to UI module management.
    /// </summary>
    UIModuleManager = 12,

    /// <summary>
    /// Context related to backend services.
    /// </summary>
    BackendService = 13,

    /// <summary>
    /// Context related to web API operations.
    /// </summary>
    WebApi = 14,

    /// <summary>
    /// Context related to StammdatenPflege.
    /// </summary>
    StammdatenPflege = 15,

    /// <summary>
    /// Context related to printing operations.
    /// </summary>
    Drucken = 16,
}

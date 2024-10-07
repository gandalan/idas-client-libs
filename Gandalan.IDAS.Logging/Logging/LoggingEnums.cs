namespace Gandalan.IDAS.Logging;

public enum LogLevel
{
    Immer = 0,
    Fehler = 1,
    Warnung = 2,
    Info = 3,
    Diagnose = 4,
}

public enum LogContext
{
    Allgemein = 0,
    Belegblatt = 1,
    Belegposition = 2,
    AV = 3,
    SLK = 4,
    UniDEx = 5,
    Adressen = 6,
    Lager = 7,
    Statistik = 8,
    Rendering = 9,
    Lizenz = 10,
    Scripting = 11,
    UIModuleManager = 12,
    BackendService = 13,
    WebApi = 14,
    StammdatenPflege = 15,
    Drucken = 16,
}

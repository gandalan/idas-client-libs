using System.Collections.Generic;
using System.Text.RegularExpressions;
using Gandalan.IDAS.WebApi.DTO;

namespace System;
public static class BelegPositionAVDTOExtension
{
    private static readonly Regex _zeilenumbruch = new(@"\s*\r?\n\s*", RegexOptions.Compiled);

    /// <summary>Ein Eintrag ist genau eine Zeile: Zeilenumbrüche in der Nachricht (z. B. Stacktrace) werden zu Leerzeichen.</summary>
    public static void AddFehlerlog(this BelegPositionAVDTO belegPosition, AVFehlerLogLevel level, string nachricht)
    {
        belegPosition.Fehlerlog ??= string.Empty;
        var einzeilig = _zeilenumbruch.Replace(nachricht ?? string.Empty, " ");
        belegPosition.Fehlerlog += $"{level.ToKuerzel()} | {einzeilig} \r\n";
    }

    /// <summary>Zeilen ohne Level-Kürzel gehören zum vorherigen Eintrag (Altbestand mit mehrzeiligen Nachrichten); vor dem ersten Eintrag gelten sie als Unbekannt.</summary>
    public static Dictionary<AVFehlerLogLevel, List<string>> GetFehlerlog(this BelegPositionAVDTO belegPosition)
    {
        var retValue = new Dictionary<AVFehlerLogLevel, List<string>>();
        if (!string.IsNullOrEmpty(belegPosition.Fehlerlog))
        {
            var aktuellesLevel = AVFehlerLogLevel.Unbekannt;
            var lines = Regex.Split(belegPosition.Fehlerlog, @"\r?\n");
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;

                aktuellesLevel = line switch
                {
                    var s when s.StartsWith("I |") => AVFehlerLogLevel.Info,
                    var s when s.StartsWith("W |") => AVFehlerLogLevel.Warning,
                    var s when s.StartsWith("E |") => AVFehlerLogLevel.Error,
                    _ => aktuellesLevel
                };
                addMessageToRetValue(retValue, aktuellesLevel, line);
            }
        }
        return retValue;
    }

    private static void addMessageToRetValue(Dictionary<AVFehlerLogLevel, List<string>> retValue, AVFehlerLogLevel level, string line)
    {
        if (retValue.TryGetValue(level, out var liste))
        {
            liste.Add(line);
        }
        else
        {
            retValue.Add(level, [line]);
        }
    }
}

public enum AVFehlerLogLevel
{
    Unbekannt = 'U',
    Info = 'I',
    Warning = 'W',
    Error = 'E'
}

public static class AVFehlerLogLevelExtensions
{
    public static char ToKuerzel(this AVFehlerLogLevel level) => (char)level;
}

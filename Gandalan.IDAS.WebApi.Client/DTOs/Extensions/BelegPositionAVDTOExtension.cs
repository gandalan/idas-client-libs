using System.Collections.Generic;
using System.Text.RegularExpressions;
using Gandalan.IDAS.WebApi.DTO;

namespace System;
public static class BelegPositionAVDTOExtension
{
    public static void AddFehlerlog(this BelegPositionAVDTO belegPosition, AVFehlerLogLevel level, string nachricht)
    {
        belegPosition.Fehlerlog ??= string.Empty;
        belegPosition.Fehlerlog += $"{level.ToKuerzel()} | {nachricht} \r\n";
    }

    public static Dictionary<AVFehlerLogLevel, List<string>> GetFehlerlog(this BelegPositionAVDTO belegPosition)
    {
        var retValue = new Dictionary<AVFehlerLogLevel, List<string>>();
        if (!string.IsNullOrEmpty(belegPosition.Fehlerlog))
        {
            var lines = Regex.Split(belegPosition.Fehlerlog, @"\r?\n");
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;

                _ = line switch
                {
                    var s when s.StartsWith("I |") => addMessageToRetValue(retValue, AVFehlerLogLevel.Info, line),
                    var s when s.StartsWith("W |") => addMessageToRetValue(retValue, AVFehlerLogLevel.Warning, line),
                    var s when s.StartsWith("E |") => addMessageToRetValue(retValue, AVFehlerLogLevel.Error, line),
                    _ => addMessageToRetValue(retValue, AVFehlerLogLevel.Unbekannt, line)
                };
            }
        }
        return retValue;
    }

    private static string addMessageToRetValue(Dictionary<AVFehlerLogLevel, List<string>> retValue, AVFehlerLogLevel level, string line)
    {
        if (retValue.TryGetValue(level, out var liste))
        {
            liste.Add(line);
        }
        else
        {
            retValue.Add(level, [line]);
        }
        return string.Empty;
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

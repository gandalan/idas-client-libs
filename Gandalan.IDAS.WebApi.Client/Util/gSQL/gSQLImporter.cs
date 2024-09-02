using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gandalan.IDAS.WebApi.Util.gSQL;

public class gSQLImporter
{
    /// <summary>
    /// Import from GSQL file
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="encoding">Use Encoding.Default if null</param>
    public static gSQLInhalt ImportFromFile(string fileName, Encoding encoding = null)
    {
        encoding ??= Encoding.Default;

        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"{fileName} nicht gefunden");
        }

        var zeilen = File.ReadAllLines(fileName, encoding);
        return import(zeilen);
    }

    /// <summary>
    /// Import from gSQLInhalt data
    /// </summary>
    /// <param name="gsqlData"></param>
    /// <param name="encoding">Use Encoding.Default if null</param>
    public static gSQLInhalt ImportFromGsqlInhalt(gSQLInhalt gsqlData, Encoding encoding = null)
    {
        encoding ??= Encoding.Default;

        var stream = new MemoryStream(encoding.GetBytes(gsqlData.ToString()));

        var zeilen = readLines(stream, encoding);
        return import(zeilen);
    }

    private static gSQLInhalt import(IEnumerable<string> zeilen)
    {
        var result = new gSQLInhalt();
        gSQLSektion aktuelleSektion = null;
        var doppelPunktPosition = 60;

        foreach (var zeile in zeilen)
        {
            if (string.IsNullOrEmpty(zeile.Trim()))
            {
                continue;
            }

            if (!zeile.StartsWith(" "))
            {
                aktuelleSektion = new gSQLSektion { Name = zeile.Trim() };
                result.Sektionen.Add(aktuelleSektion);
            }
            else if (aktuelleSektion != null)
            {
                var zeileBereinigt = zeile.Trim();
                if (zeileBereinigt.StartsWith("DatenFormat"))
                {
                    var format = zeileBereinigt.Substring(zeileBereinigt.IndexOf(':') + 1);
                    if (format.StartsWith("gSQL"))
                    {
                        doppelPunktPosition = int.Parse(format.Replace("gSQL", ""));
                    }
                }

                var itemName = zeile.Substring(0, doppelPunktPosition).Trim();
                var itemWert = zeile.Substring(doppelPunktPosition + 1).Trim();

                aktuelleSektion.Items.Add(new gSQLItem
                {
                    Name = itemName,
                    Wert = itemWert,
                });
            }
        }

        return result;
    }

    private static IEnumerable<string> readLines(Stream stream, Encoding encoding)
    {
        var lines = new List<string>();

        using (var reader = new StreamReader(stream, encoding))
        {
            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }
        }

        return lines;
    }
}

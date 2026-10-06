using System.Text;

namespace Gandalan.IDAS.Contracts.Extensions;

/// <summary>
/// Zeilenumbrüche für Texte, die Teil des API-Contracts sind (Response-Felder,
/// in der Datenbank persistierte Texte): immer Windows-CRLF ("\r\n"), unabhängig
/// vom Hosting-OS. <see cref="StringBuilder.AppendLine()"/> nutzt Environment.NewLine
/// und liefert auf Linux nur "\n" — die Legacy-API (Windows) ist der Contract.
/// </summary>
public static class NewLines
{
    /// <summary>Windows-CRLF, hosting-unabhängig — für contract-relevante Texte statt Environment.NewLine.</summary>
    public const string Windows = "\r\n";
}

public static class StringBuilderExtensions
{
    /// <summary>Hängt CRLF an — Ersatz für AppendLine() bei contract-relevanten Texten.</summary>
    public static StringBuilder AppendWindowsLine(this StringBuilder sb)
        => sb.Append(NewLines.Windows);

    /// <summary>Hängt den Wert plus CRLF an — Ersatz für AppendLine(value) bei contract-relevanten Texten.</summary>
    public static StringBuilder AppendWindowsLine(this StringBuilder sb, string value)
        => sb.Append(value).Append(NewLines.Windows);
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.Contracts.Extensions;

/// <summary>
/// Baut Anzeigetexte aus mehreren Teilen zusammen, ohne "nackte" Trenner:
/// leere, null- oder Whitespace-Teile werden übersprungen, sodass der Trenner
/// nur zwischen tatsächlich gefüllten Teilen steht.
/// </summary>
public static class StringJoiner
{
    /// <summary>
    /// Verbindet alle gefüllten Teile mit dem Trenner. Null-, leere und
    /// Whitespace-Teile werden übersprungen.
    /// </summary>
    public static string JoinNonEmpty(string separator, params string[] parts)
        => JoinNonEmpty(separator, (IEnumerable<string>)parts);

    /// <summary>
    /// Verbindet alle gefüllten Teile mit dem Trenner. Null-, leere und
    /// Whitespace-Teile werden übersprungen.
    /// </summary>
    public static string JoinNonEmpty(string separator, IEnumerable<string> parts)
    {
        if (parts == null)
        {
            return string.Empty;
        }

        return string.Join(separator, parts.Where(p => !string.IsNullOrWhiteSpace(p)));
    }

    /// <summary>
    /// Verbindet gemischte Werte (z. B. string, decimal, DateTime) mit dem Trenner.
    /// Werte werden über den <paramref name="provider"/> formatiert; null-Werte und
    /// Werte, die zu leeren Strings formatieren, werden übersprungen.
    /// </summary>
    public static string JoinNonEmpty(string separator, IFormatProvider provider, params object[] parts)
    {
        if (parts == null)
        {
            return string.Empty;
        }

        return JoinNonEmpty(separator, parts.Select(p => Convert.ToString(p, provider)));
    }

    /// <summary>
    /// Umschließt einen gefüllten Wert mit Präfix und Suffix, z. B. "(Muster, Max)".
    /// Ist der Wert null, leer oder Whitespace, wird ein leerer String geliefert.
    /// </summary>
    public static string WrapIfNotEmpty(string prefix, string value, string suffix)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        return prefix + value + suffix;
    }
}

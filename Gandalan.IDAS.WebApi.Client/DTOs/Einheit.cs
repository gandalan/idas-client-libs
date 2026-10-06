using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Zentrale, einzige Quelle für Mengeneinheiten-Schreibweisen.
/// Die Stammdaten (IGOR2 u.a.) liefern uneinheitliche Schreibweisen; über
/// <see cref="AsNormalizedEinheit"/> werden sie auf die hier definierten kanonischen
/// Konstanten normalisiert. Vergleiche im übrigen Code müssen über diese Konstanten
/// bzw. die Ist*-Prädikate laufen – NICHT über String-Literale.
/// </summary>
public static class Einheit
{
    public const string Stueck = "St.";
    public const string Laufmeter = "lfm";
    public const string Satz = "Sa.";
    public const string Millimeter = "mm";
    public const string Quadratmeter = "qm";
    public const string Stunde = "Std.";
    public const string Kilogramm = "kg";
    public const string Liter = "l";
    public const string Meter = "m";

    private static readonly Dictionary<string, string> _einheitLookup =
        new(StringComparer.OrdinalIgnoreCase)
        {
            // St.
            ["st."] = Stueck,
            ["st"] = Stueck,
            ["stk."] = Stueck,
            ["stk"] = Stueck,
            ["stck."] = Stueck,
            ["stck"] = Stueck,
            ["1 stk."] = Stueck,
            ["1 stk"] = Stueck,
            ["stück"] = Stueck,

            // lfm
            ["lfm"] = Laufmeter,
            ["lfm."] = Laufmeter,

            // Sa.
            ["satz"] = Satz,
            ["satz."] = Satz,
            ["sa."] = Satz,
            ["sa"] = Satz,
            ["set"] = Satz,

            // Std.
            ["h"] = Stunde,
            ["std"] = Stunde,
            ["std."] = Stunde,

            // qm
            ["qm"] = Quadratmeter,
            ["m²"] = Quadratmeter,
            ["m2"] = Quadratmeter,
            ["quadratmeter"] = Quadratmeter,

            // mm
            ["mm"] = Millimeter,
            ["millimeter"] = Millimeter,

            // kg
            ["kg"] = Kilogramm,
            ["kilogramm"] = Kilogramm,

            // l
            ["l"] = Liter,
            ["liter"] = Liter,
            ["ltr"] = Liter,

            // m
            ["m"] = Meter,
            ["meter"] = Meter,
        };

    /// <summary>
    /// Normalisiert eine beliebige Einheiten-Schreibweise auf die kanonische Konstante.
    /// Leere/unbekannte Werte: leer → <see cref="Stueck"/>, unbekannt → unverändert zurück.
    /// </summary>
    public static string AsNormalizedEinheit(this string einheit)
    {
        if (string.IsNullOrWhiteSpace(einheit))
        {
            return Stueck;
        }

        return _einheitLookup.TryGetValue(einheit.Trim(), out var target)
            ? target
            : einheit;
    }

    /// <summary>Prüft (nach Normalisierung), ob die Einheit Laufmeter ist.</summary>
    public static bool IstLaufmeter(this string einheit) => einheit.AsNormalizedEinheit() == Laufmeter;

    /// <summary>Prüft (nach Normalisierung), ob die Einheit Stück ist.</summary>
    public static bool IstStueck(this string einheit) => einheit.AsNormalizedEinheit() == Stueck;

    /// <summary>Prüft (nach Normalisierung), ob die Einheit Satz ist.</summary>
    public static bool IstSatz(this string einheit) => einheit.AsNormalizedEinheit() == Satz;

    /// <summary>Prüft (nach Normalisierung), ob die Einheit Quadratmeter ist.</summary>
    public static bool IstQuadratmeter(this string einheit) => einheit.AsNormalizedEinheit() == Quadratmeter;
}

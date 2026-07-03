using System;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO;

// <summary>
// Statische Klasse, die alle Berechtigungen als Konstanten enthält. Diese können in der gesamten Anwendung verwendet werden, um Berechtigungen zu überprüfen.
// Synced von Dev 2026-03-13
// </summary>
public static class Permissions
{
    public const string Adressverwaltung = "Adressverwaltung";
    public const string Belege = "Belege";
    public const string BelegeStamm = "BelegeStamm";
    public const string ProduktionAV = "ProduktionAV";
    public const string ProduktionStamm = "ProduktionStamm";
    public const string ProduktionSLK = "ProduktionSLK";
    public const string Lager = "Lager";
    public const string Statistik = "Statistik";
    public const string Zeit = "Zeit";
    public const string ZeitStamm = "ZeitStamm";
    public const string Touren = "Touren";
    public const string TourenStamm = "TourenStamm";
    public const string Vertreter = "Vertreter";
    public const string Bestellfix = "Bestellfix";
    public const string AdminTool = "AdminTool";
    public const string UserAdmin = "UserAdmin";
    public const string AlleBelegeEinsehen = "AlleBelegeEinsehen";
    public const string AppAdmin = "AppAdmin";
    public const string SettingsSchreiben = "SettingsSchreiben";
    public const string ReportSchreiben = "ReportSchreiben";
    public const string AddonInstall = "AddonInstall";
    public const string AddonAdmin = "AddonAdmin";
    public const string FeedbackAdmin = "FeedbackAdmin";
    public const string Anwendungstester = "Anwendungstester";
    public const string IntegrityCheckToolUser = "IntegrityCheckToolUser";
    public const string NeherApp3Dev = "NeherApp3-Dev";
    public const string C3DiffUse = "c3diff:use";
}

/// <summary>
/// Stellt Erweiterungsmethoden zur Auswertung von Berechtigungen für eine <see cref="BenutzerDTO"/>-Instanz bereit.
/// </summary>
/// <remarks>
/// Diese Erweiterungsmethoden ermöglichen Berechtigungsprüfungen anhand der einem Benutzer zugewiesenen Rollen und Berechtigungen.
/// Sie dienen dazu, die Logik zur Berechtigungsprüfung in der gesamten Anwendung zu vereinfachen.
/// </remarks>
public static class PermissionExtensions
{
    /// <summary>
    /// Ermittelt, ob das angegebene <see cref="BenutzerDTO"/> über die angegebene Berechtigung verfügt.
    /// </summary>
    /// <param name="benutzer">Die zu prüfende <see cref="BenutzerDTO"/>-Instanz.</param>
    /// <param name="permission">Die zu prüfende Berechtigung.</param>
    /// <returns><see langword="true"/>, wenn das <see cref="BenutzerDTO"/> über die angegebene Berechtigung verfügt, andernfalls <see langword="false"/>.</returns>
    public static bool HasPermission(this BenutzerDTO benutzer, string permission)
    {
        return benutzer?.Rollen?.Any(r => r.Berechtigungen?.Any(b => b.Code.Equals(permission, StringComparison.OrdinalIgnoreCase)) ?? false) ?? false;
    }
}

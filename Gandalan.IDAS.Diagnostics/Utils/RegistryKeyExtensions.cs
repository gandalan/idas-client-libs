using System;
using Gandalan.IDAS.Logging;
using Microsoft.Win32;

namespace Gandalan.IDAS.Diagnostics.Utils;

/// <summary>
/// Helper Klasse zum Arbeiten mit <see cref="RegistryKey"/>s
/// </summary>
public static class RegistryKeyExtensions
{
    /// <summary>
    /// Zieht den String Wert eines Registry Eintrags oder gibt null zurück, wenn dieser nicht vorhanden ist oder nicht sonst nicht gelesen werden kann.
    /// </summary>
    /// <param name="key">Der <see cref="RegistryKey"/></param>
    /// <param name="name">Name des Registry Eintrags</param>
    /// <returns>String Wert des <see cref="RegistryKey"/> oder null</returns>
    public static string TryGetStringValue(this RegistryKey key, string name)
    {
        try
        {
            return key.GetValue(name)?.ToString();
        }
        catch (Exception e)
        {
            L.Fehler(e);
        }

        return null;
    }
}

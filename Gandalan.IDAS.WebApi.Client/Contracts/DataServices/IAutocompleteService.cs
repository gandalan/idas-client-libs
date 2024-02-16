using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    /// <summary>
    /// Liefert gespeicherte Ergebnisse für AutoCompleteFelder
    /// </summary>
    public interface IAutocompleteService
    {
        /// <summary>
        /// Ruft alle vorhandenen Einträge ab
        /// </summary>
        Task<List<string>> GetAllAsync(int? top = null);
        /// <summary>
        /// Fügt einen neuen Eintrag hinzu
        /// </summary>
        /// <param name="word">Das neue Wort, welches gespeichert werden soll</param>
        Task AddAsync(string word);
        /// <summary>
        /// Fügt einen neuen Eintrag hinzu
        /// </summary>
        /// <param name="word">Das zu löschende Wort</param>
        Task DeleteAsync(string word);
        /// <summary>
        /// Lädt die Einstellungen / Wörter
        /// </summary>
        /// <param name="settingsKey">Schlüssel, anhand dem die Einstellungen geladen werden sollen</param>
        Task Load(string settingsKey, bool isReleoad = false);
        /// <summary>
        /// Speichert die Einstellungen / Wörter
        /// </summary>
        Task Save();
    }
}

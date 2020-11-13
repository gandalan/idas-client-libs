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
        Task<List<string>> GetAllAsync();
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
    }
}

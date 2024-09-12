using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Lager;

public interface ILagerVerwaltung
{
    /// <summary>
    /// Opens the main entry point of the LagerVerwaltung.
    /// </summary>
    public Task OpenAsync();
}

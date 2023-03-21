using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IArtikelAssetsService
    {        
        Task<byte[]> GetAssetAsync(string katalognummer, string extension, int width = 0, int height = 0, int stroke = 20);
    }
}

using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IFileService
    {
        Task<byte[]> GetFileAsync(string name);
        Task<FileInfoDTO[]> GetFileListAsync(string directory = "");
        Task SaveFileAsync(string fileName, byte[] data);
        Task DeleteFileAsync(string fileName);
    }
}

using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IFileService
    {
        byte[] GetFile(string name);
        Task<byte[]> GetFileAsync(string name);
        FileInfoDTO[] GetFileList(string directory = "");
        Task<FileInfoDTO[]> GetFileListAsync(string directory = "");
        void SaveFile(string fileName, byte[] data);
        Task SaveFileAsync(string fileName, byte[] data);
        void DeleteFile(string fileName);
        Task DeleteFileAsync(string fileName);
    }
}

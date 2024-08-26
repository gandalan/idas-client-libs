using System.IO;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.File;

public interface IFileHelper
{
    void SaveFile(string fileNameWithPath, Stream fileContent);
    Stream GetFileStream(string fileNameWithPath);
    bool FileExists(string fileNameWithPath);
    FileInfoDTO[] GetFiles(string path);
    void DeleteFile(string fileNameWithPath);
    void MoveFile(string fileFromWithPath, string fileToWithPath);
}
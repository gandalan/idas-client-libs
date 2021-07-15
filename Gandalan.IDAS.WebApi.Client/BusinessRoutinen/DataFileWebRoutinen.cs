using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    /// <summary>
    /// Stellt Methoden zur Verfügung um beliebige Dateien auf dem Server zu speichern abzufragen und zu löschen.
    /// Der FileName kann auch Pfade enthalten um der Ablage eine Struktur zu geben.
    /// Die Dateien werden in einem Mandantenspezifischen Speicher abgelegt.
    /// </summary>
    public class DataFileWebRoutinen : WebRoutinenBase
    {
        public DataFileWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public byte[] GetFile(string filename)
        {
            if (Login())
            {
                return GetData("DataFile/?filename=" + filename);
            }
            return null;
        }

        public FileInfoDTO[] GetFileList()
        {
            if (Login())
            {
                return Get<FileInfoDTO[]>("DataFile/");
            }
            return null;
        }
                
        public void SaveFile(string fileName, byte[] data)
        {
            if (Login())
            {
                PutData("DataFile/?filename=" + fileName, data);
            }
        }

        public string DeleteFile(string fileName)
        {
            if (Login())
            {
                return Delete("DataFile/?filename=" + fileName);
            }
            return "Not logged in";
        }

        public async Task SaveFileAsync(string fileName, byte[] data)
        {
            await Task.Run(() => SaveFile(fileName, data));
        }

        public async Task<FileInfoDTO[]> GetFileListAsync()
        {
            return await Task.Run(() => GetFileList());
        }

        public async Task<byte[]> GetFileAsync(string filename)
        {
            return await Task.Run(() => GetFile(filename));
        }

        public async Task<string> DeleteFileAsync(string filename)
        {
            return await Task.Run(() => DeleteFile(filename));
        }
    }
}
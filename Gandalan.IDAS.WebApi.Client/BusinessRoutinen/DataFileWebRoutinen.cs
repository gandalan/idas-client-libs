using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
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

        public async Task<byte[]> GetFileAsync(string filename)
            => await GetDataAsync("DataFile/?filename=" + filename);

        public async Task<FileInfoDTO[]> GetFileListAsync(string directory = "/") 
            => await GetAsync<FileInfoDTO[]>($"DataFile/?subdir={Uri.EscapeDataString(directory)}");

        public async Task SaveFileAsync(string fileName, byte[] data) 
            => await PutDataAsync("DataFile/?filename=" + fileName, data);

        public async Task DeleteFileAsync(string filename)
            => await DeleteAsync($"DataFile/?filename={filename}");

    }
}
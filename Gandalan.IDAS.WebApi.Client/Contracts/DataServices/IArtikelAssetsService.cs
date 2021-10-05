using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IArtikelAssetsService
    {        
        Task<byte[]> GetAssetAsync(string katalognummer, string extension, int width = 0, int height = 0, int stroke = 20);
    }
}

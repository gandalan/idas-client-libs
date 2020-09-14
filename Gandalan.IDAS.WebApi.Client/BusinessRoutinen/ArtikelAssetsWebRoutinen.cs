using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ArtikelAssetsWebRoutinen : WebRoutinenBase
    {
        public ArtikelAssetsWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
        public byte[] GetSchnitt(string katalognummer, string extension, int width = 0, int height = 0)
        {
            if (Login())
            {
                return GetData($"ArtikelAssets?katalognummer={katalognummer}&extension={extension}&width={width}&height={height}");
            }
            return null;
        }
        
        public async Task<byte[]> GetSchnittAsync(string katalognummer, string extension, int width = 0, int height = 0)
        {
            return await Task.Run(() => GetSchnitt(katalognummer, extension, width, height));
        }
    }
}
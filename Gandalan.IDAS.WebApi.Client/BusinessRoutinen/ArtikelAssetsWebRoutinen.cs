using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ArtikelAssetsWebRoutinen : WebRoutinenBase
    {
        public ArtikelAssetsWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
        public byte[] GetSchnitt(string katalognummer, string extension, int width = 0, int height = 0, int stroke = 20)
        {
            if (Login())
            {
                return GetData($"ArtikelAssets?katalognummer={katalognummer}&extension={extension}&width={width}&height={height}&stroke={stroke}");
            }
            return null;
        }
        
        public async Task<byte[]> GetSchnittAsync(string katalognummer, string extension, int width = 0, int height = 0, int stroke = 20)
        {
            return await Task.Run(() => GetSchnitt(katalognummer, extension, width, height, stroke));
        }
    }
}
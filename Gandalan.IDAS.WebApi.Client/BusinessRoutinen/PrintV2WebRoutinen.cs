using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class PrintV2WebRoutinen : WebRoutinenBase
    {
        public PrintV2WebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<byte[]> PdfAsync(Guid bguid, string email)
            => await GetDataAsync("PrintV2/Pdf?bguid=" + bguid + "&email=" + Uri.EscapeDataString(email));
    }
}

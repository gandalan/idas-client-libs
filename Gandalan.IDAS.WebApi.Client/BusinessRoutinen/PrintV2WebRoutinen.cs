using Gandalan.IDAS.Client.Contracts.Contracts;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class PrintV2WebRoutinen : WebRoutinenBase
    {
        public PrintV2WebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public byte[] Pdf(Guid bguid, string email)
        {
            return GetData("PrintV2/Pdf?bguid=" + bguid + "&email=" + System.Uri.EscapeDataString(email));
        }

        public async Task<byte[]> PdfAsync(Guid bguid, string email)
        {
            return await Task<byte[]>.Run(() => Pdf(bguid, email));
        }

    }
}

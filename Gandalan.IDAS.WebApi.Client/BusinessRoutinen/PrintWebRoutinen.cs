using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class PrintWebRoutinen : WebRoutinenBase
    {
        public PrintWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<byte[]> PDFErzeugenAsync(Guid belegGuid)
            => await PostDataAsync("Print/?bguid=" + belegGuid.ToString(), new byte[0]);

        public async Task<byte[]> XPSErzeugenAsync(Guid belegGuid) 
            => await PostDataAsync("Print/?bguid=" + belegGuid.ToString() + "&fileFormat=XPS", new byte[0]);
    }
}

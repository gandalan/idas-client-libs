using Gandalan.IDAS.Client.Contracts.Contracts;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class PrintV2WebRoutinen : WebRoutinenBase
    {
        public PrintV2WebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public byte[] Pdf(string vorgangNumer, string email, bool onlyBills)
        {
            return GetData("PrintV2/Pdf?vorgangNumer=" + vorgangNumer + "&email=" + email + "&nurRechnungen=" + onlyBills);
        }

        public async Task<byte[]> PdfAsync(string vorgangNumer, string email, bool onlyBills)
        {
            return await Task<byte[]>.Run(() => Pdf(vorgangNumer, email, onlyBills));
        }

    }
}

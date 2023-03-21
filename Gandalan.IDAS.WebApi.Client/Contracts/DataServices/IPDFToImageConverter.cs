using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IPDFToImageConverter
    {
        Task<List<string>> ConvertPDFListToImages(List<string> pdfList, string outputFolder);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.Client.Common.Contracts.UIServices;
using Gandalan.Client.Common.UI;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IPDFDisplay
    {
        void DisplayPDF(string path);
    }

    public interface IPDFDisplayContainer
    {
        void SetControl(object control);
    }

    public class PDFDisplayImplDefault : IPDFDisplay
    {
        public void DisplayPDF(string path)
        {
            if (!string.IsNullOrEmpty(path))
                System.Diagnostics.Process.Start(path);
        }
    }
}

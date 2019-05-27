using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface ILoginService
    {
        bool Login();
        bool VerifySavedAuthToken();
    }
}

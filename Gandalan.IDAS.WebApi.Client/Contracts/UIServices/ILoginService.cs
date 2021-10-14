using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface ILoginService
    {
        bool SaveDefaultEnvironment { get; }

        bool Login();
        Task<bool> LoginAsync();
        bool VerifySavedAuthToken();
        Task<bool> VerifySavedAuthTokenAsync();
    }
}

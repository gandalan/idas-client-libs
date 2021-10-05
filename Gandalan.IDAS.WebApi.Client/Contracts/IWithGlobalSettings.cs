using Gandalan.Client.Contracts.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts
{
    public interface IWithGlobalSettings
    {
        void SetGlobalSettings(IApplicationConfig appConfig, IWebApiConfig webApiSettings);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.Client.Contracts.UIServices;

namespace Gandalan.Client.Contracts.AppServices
{
    public interface IApplicationUpdateCheckService
    {
        void LoadUpdateCheck();
    }
}

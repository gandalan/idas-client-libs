using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Store
{
    public interface IPackageStoreUpdate

    {
        bool MustRestartApp { get; set; }
        event EventHandler<string> OnPackageUpdate;

        void UpdatePackages();
    }
}

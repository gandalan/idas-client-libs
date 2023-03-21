using System;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Store
{
    public interface IPackageStoreUpdate

    {
        bool MustRestartApp { get; set; }
        event EventHandler<string> OnPackageUpdate;
        [Obsolete]
        void UpdatePackages();
        void UpdatePackages(string basePath);
    }
}

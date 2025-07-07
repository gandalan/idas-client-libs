using System;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Store;

public interface IPackageStoreUpdate

{
    bool MustRestartApp { get; set; }
    event EventHandler<string> OnPackageUpdate;
    void UpdatePackages(string basePath);
}

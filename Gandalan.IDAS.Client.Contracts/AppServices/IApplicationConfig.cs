using System;

namespace Gandalan.Client.Contracts.AppServices
{
    public interface IApplicationConfig
    {
        Guid AppToken { get; }
        string UpdateUrl { get; }
        string TargetEnvironment { get; }
        Guid InstallationId { get; }
        string LocalDataDir { get; }
    }
}

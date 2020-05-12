using System;

namespace Gandalan.Client.Contracts.AppServices
{
    public interface IApplicationConfig
    {
        Guid AppToken { get; }
        string UpdateUrl { get; }
        string TargetEnvironment { get; set; }
        Guid InstallationId { get; }
        string LocalDataDir { get; }
        bool DeveloperModeEnabled { get; }
        string ApplicationName { get; }
        string IconPath { get; }
        string SplashPath { get; }
    }
}

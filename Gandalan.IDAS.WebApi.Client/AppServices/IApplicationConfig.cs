using System;

namespace Gandalan.Client.Contracts.AppServices
{
    public interface IApplicationConfig
    {
        Guid AppToken { get; }
        string UpdateUrl { get; }
        string TargetEnvironment { get; set; }
        string AppConfigDirectory { get; set; }
        string CurrentUser { get; set; }
        Guid InstallationId { get; }
        string DataDir { get; }
        string AddOnDir { get; }
        string CacheDir { get; }
        string SettingsDir { get; }
        bool DeveloperModeEnabled { get; }
        string ApplicationName { get; }
        string IconPath { get; }
        string SplashPath { get; }
        bool IsFirstRun { get; set; }
        string ChangeLogFileName { get; set; }
    }
}

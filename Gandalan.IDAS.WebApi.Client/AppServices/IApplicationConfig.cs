using System;
using Gandalan.IDAS.WebApi.Client.Environments;

namespace Gandalan.Client.Contracts.AppServices;

public interface IApplicationConfig
{
    Guid AppToken { get; }
    string UpdateUrl { get; }
    DeploymentEnvironment TargetEnvironment { get; set; }
    string AppConfigDirectory { get; set; }
    string CurrentUser { get; set; }
    Guid InstallationId { get; }
    string DataDir { get; }
    string StandardReportsDir { get; }
    string StandardReportsDevDir { get; }
    string AddOnDir { get; }
    string CacheDir { get; }
    string UserSettingsDir { get; }
    string AppSettingsDir { get; }
    bool DeveloperModeEnabled { get; }
    string ApplicationName { get; }
    string IconPath { get; }
    string SplashPath { get; }
    bool IsFirstRun { get; set; }
    bool IsAdditionalInstance { get; set; }
    string ChangeLogFileName { get; set; }
    bool IsSafeMode { get; set; }
    bool UsingAppPath { get; set; }

}

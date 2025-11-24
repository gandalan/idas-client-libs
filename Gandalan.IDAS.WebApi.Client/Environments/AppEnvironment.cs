using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.Environments;

public static class AppEnvironment
{
#if DEPLOYMENTENVIRONMENT_DEV
    public const DeploymentEnvironment CurrentEnvironment  = DeploymentEnvironment.Development;
#elif DEPLOYMENTENVIRONMENT_STAGE
    public const DeploymentEnvironment CurrentEnvironment  = DeploymentEnvironment.Staging;
#elif DEPLOYMENTENVIRONMENT_PROD
    public const DeploymentEnvironment CurrentEnvironment  = DeploymentEnvironment.Production;
#elif DEPLOYMENTENVIRONMENT_LOCAL
    public const DeploymentEnvironment CurrentEnvironment = DeploymentEnvironment.Local;
#else
    public const DeploymentEnvironment CurrentEnvironment = DeploymentEnvironment.Unknown;
#endif

    public static bool IsProduction => CurrentEnvironment == DeploymentEnvironment.Production;
    public static bool IsStaging => CurrentEnvironment == DeploymentEnvironment.Staging;
    public static bool IsDevelopment => CurrentEnvironment == DeploymentEnvironment.Development;
    public static bool IsLocal => CurrentEnvironment == DeploymentEnvironment.Local;

    public static bool IsUnknown => CurrentEnvironment == DeploymentEnvironment.Unknown;

    private static readonly IReadOnlyDictionary<string, DeploymentEnvironment> _nameToEnvironment =
        new Dictionary<string, DeploymentEnvironment>(StringComparer.OrdinalIgnoreCase)
        {
            // Friendly
            ["release"] = DeploymentEnvironment.Production,
            ["preview"] = DeploymentEnvironment.Staging,
            ["dev"] = DeploymentEnvironment.Development,
            ["local"] = DeploymentEnvironment.Local,

            // Short
            ["prod"] = DeploymentEnvironment.Production,
            ["staging"] = DeploymentEnvironment.Staging,
        };

    public static string ToShortName(DeploymentEnvironment deploymentEnvironment) => deploymentEnvironment switch
    {
        DeploymentEnvironment.Staging => "staging",
        DeploymentEnvironment.Development => "dev",
        DeploymentEnvironment.Local => "local",
        _ => deploymentEnvironment.ToString().ToLowerInvariant()
    };

    public static string ToFriendlyName(DeploymentEnvironment deploymentEnvironment) => deploymentEnvironment switch
    {
        DeploymentEnvironment.Production => "release",
        DeploymentEnvironment.Staging => "preview",
        DeploymentEnvironment.Development => "dev",
        DeploymentEnvironment.Local => "local",
        _ => deploymentEnvironment.ToString().ToLowerInvariant()
    };

    
    public static bool TryParse(string name, out DeploymentEnvironment deploymentEnvironment)
    {
        deploymentEnvironment = DeploymentEnvironment.Unknown;

        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        var key = name.Trim();

        if (_nameToEnvironment.TryGetValue(key, out deploymentEnvironment))
        {
            return true;
        }

        // fallback to enumName
        return Enum.TryParse(key, ignoreCase: true, out deploymentEnvironment);
    }
}

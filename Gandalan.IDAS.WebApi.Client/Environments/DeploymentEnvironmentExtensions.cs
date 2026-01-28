namespace Gandalan.IDAS.WebApi.Client.Environments;

public static class DeploymentEnvironmentExtensions
{
    public static string ToFriendlyName(this DeploymentEnvironment deploymentEnvironment)
        => AppEnvironment.ToFriendlyName(deploymentEnvironment);

    public static string ToShortName(this DeploymentEnvironment deploymentEnvironment)
        => AppEnvironment.ToShortName(deploymentEnvironment);
    public static string ToOldName(this DeploymentEnvironment deploymentEnvironment)
        => AppEnvironment.ToOldName(deploymentEnvironment);
}

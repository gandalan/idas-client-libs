namespace Gandalan.IDAS.WebApi.Client.Environments;

public static class StageExtensions
{
    public static string ToFriendlyName(this Stages stage) => stage switch
    {
        Stages.Prod => "release",
        Stages.Test => "preview",
        Stages.Dev => "dev",
        Stages.Local => "local",
        _ => stage.ToString().ToLowerInvariant()
    };
}

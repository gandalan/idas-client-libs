using System.Runtime.Serialization;

namespace Gandalan.IDAS.WebApi.Client.Environments;

[System.Text.Json.Serialization.JsonConverter(typeof(DeploymentEnvironmentJsonConverter))]
[Newtonsoft.Json.JsonConverter(typeof(DeploymentEnvironmentNewtonsoftConverter))]
public enum DeploymentEnvironment
{
    [EnumMember(Value = "Unbekannt")]
    Unknown,
    [EnumMember(Value = "Release")]
    Production,
    [EnumMember(Value = "Preview")]
    Staging,
    [EnumMember(Value = "Dev")]
    Development,
    [EnumMember(Value = "Local")]
    Local
}

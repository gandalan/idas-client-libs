using System.Runtime.Serialization;

namespace Gandalan.IDAS.WebApi.Client.Environments;

[System.Text.Json.Serialization.JsonConverter(typeof(DeploymentEnvironmentJsonConverter))]
[Newtonsoft.Json.JsonConverter(typeof(DeploymentEnvironmentNewtonsoftConverter))]
public enum DeploymentEnvironment
{
    [EnumMember(Value = "Unbekannt")]
    Unknown,
    [EnumMember(Value = "prod")]
    Production,
    [EnumMember(Value = "stg")]
    Staging,
    [EnumMember(Value = "dev")]
    Development,
    [EnumMember(Value = "Local")]
    Local
}

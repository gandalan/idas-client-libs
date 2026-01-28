using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gandalan.IDAS.WebApi.Client.Environments;
public sealed class DeploymentEnvironmentJsonConverter : JsonConverter<DeploymentEnvironment>
{
    private readonly Func<DeploymentEnvironment, string> _serializeNameSelector;

    public DeploymentEnvironmentJsonConverter(bool useShortName = false)
    {
        _serializeNameSelector = useShortName
            ? AppEnvironment.ToShortName
            : AppEnvironment.ToFriendlyName;
    }

    public override DeploymentEnvironment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var environment = reader.GetString();

            if (AppEnvironment.TryParse(environment, out var deploymentEnvironment))
            {
                return deploymentEnvironment;
            }

            throw new JsonException($"Unknown deployment environment name: '{environment}'.");
        }

        throw new JsonException($"Unexpected token {reader.TokenType} for DeploymentEnvironment.");
    }

    public override void Write(Utf8JsonWriter writer, DeploymentEnvironment value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_serializeNameSelector(value));
    }
}

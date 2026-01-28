using System;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Environments;
public sealed class DeploymentEnvironmentNewtonsoftConverter : JsonConverter
{
    private readonly Func<DeploymentEnvironment, string> _serializeNameSelector;

    public DeploymentEnvironmentNewtonsoftConverter(bool useShortName = false)
    {
        _serializeNameSelector = useShortName
            ? AppEnvironment.ToShortName
            : AppEnvironment.ToFriendlyName;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DeploymentEnvironment);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.String)
        {
            var environment = (string)reader.Value;

            if (AppEnvironment.TryParse(environment, out var deploymentEnvironment))
            {
                return deploymentEnvironment;
            }

            throw new JsonSerializationException($"Unknown deployment environment name: '{environment}'.");
        }

        throw new JsonSerializationException($"Unexpected token {reader.TokenType} for DeploymentEnvironment.");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var environment = (DeploymentEnvironment)value;
        writer.WriteValue(_serializeNameSelector(environment));
    }
}

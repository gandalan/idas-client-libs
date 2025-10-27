using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.Client.Environments;

public static class EnvironmentStages
{
    private static readonly Dictionary<EnvironmentStage, List<string>> _environmentStagesAliases = new()
    {
        { EnvironmentStage.Production, ["prod", "produktion", "production", "release"] },
        { EnvironmentStage.Testing, ["stage", "test", "testing", "staging",  "preprod", "preview"] },
        { EnvironmentStage.Development, ["dev", "entwicklung", "development"] }
    };

    public static EnvironmentStage GetDefaultEnvironmentStage() => EnvironmentStage.Production;
    public static string GetDefaultEnvironmentStageName() => GetDefaultEnvironmentStage().ToString().ToLowerInvariant();

    public static bool TryGetEnvironmentStageName(string alias, out string stageName)
    {
        stageName = null;

        if (alias.StartsWith("local"))
        {
            stageName = alias;
            return true;
        }

        if (TryGetEnvironmentStage(alias, out var stage))
        {
            stageName = _environmentStagesAliases[stage].First();
            return true;
        }

        return false;
    }

    public static bool TryGetEnvironmentStage(string alias, out EnvironmentStage stage)
    {
        stage = default;

        if (string.IsNullOrWhiteSpace(alias))
        {
            return false;
        }

        if (alias.StartsWith("local"))
        {
            stage = EnvironmentStage.Custom;
            return true;
        }

        foreach (var kvp in _environmentStagesAliases)
        {
            if (kvp.Value.Contains(alias, StringComparer.OrdinalIgnoreCase))
            {
                stage = kvp.Key;
                return true;
            }
        }

        return false;
    }

    public static bool ValidateEnvironmentStage(string stage)
    {
        if (string.IsNullOrWhiteSpace(stage))
        {
            return false;
        }

        return _environmentStagesAliases
                   .Values
                   .Any(stageValueList => stageValueList.Contains(stage, StringComparer.OrdinalIgnoreCase))
               || stage.StartsWith("local"); // custom stages must begin with 'local'
    }
}

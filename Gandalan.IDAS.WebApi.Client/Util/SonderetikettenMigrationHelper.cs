using System.Collections.Generic;

using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.Client.Util;

public static class SonderetikettenMigrationHelper
{
    private const string SonderetikettenSubObjectName = "sonderetiketten";

    public static PropertyValueCollection GetSonderetiketten<T>(T dtoWithProperties)
        where T : IDTOWithAdditionalProperties, IDTOWithApplicationSpecificProperties
    {
        if (dtoWithProperties is null)
            return [];

        if (IsMigrationNecessary(dtoWithProperties))
        {
            MigrateSonderetiketten(dtoWithProperties);
        }

        return dtoWithProperties.AdditionalProperties.GetSubObject(SonderetikettenSubObjectName) ?? [];
    }

    public static void MigrateSonderetiketten<T>(T dtoWithProperties)
        where T : IDTOWithAdditionalProperties, IDTOWithApplicationSpecificProperties
    {
        var appSpecificSonderetikettenProperties = dtoWithProperties.ApplicationSpecificProperties.GetSubObject(SonderetikettenSubObjectName);

        if (appSpecificSonderetikettenProperties?.Count > 0)
        {
            var sonderetikettenAsAdditionalProperties = dtoWithProperties.AdditionalProperties.GetSubObject(SonderetikettenSubObjectName);

            if (sonderetikettenAsAdditionalProperties == null || sonderetikettenAsAdditionalProperties.Count == 0)
            {
                dtoWithProperties.AdditionalProperties.SetSubObject(SonderetikettenSubObjectName, appSpecificSonderetikettenProperties);
                dtoWithProperties.ApplicationSpecificProperties.DeleteSubObject(SonderetikettenSubObjectName);
            }
        }
    }

    public static bool IsMigrationNecessary<T>(T dtoWithProperties)
        where T : IDTOWithAdditionalProperties, IDTOWithApplicationSpecificProperties
    {
        if (dtoWithProperties == null)
            return false;

        return IsMigrationNecessary(dtoWithProperties.ApplicationSpecificProperties, dtoWithProperties.AdditionalProperties);
    }

    public static bool IsMigrationNecessary(
        Dictionary<string, PropertyValueCollection> appSpecificProperties,
        Dictionary<string, PropertyValueCollection> additionalProperties)
    {
        var appSpecificSonderetikettenProperties = appSpecificProperties.GetSubObject(SonderetikettenSubObjectName);
        var sonderetikettenAsAdditionalProperties = additionalProperties.GetSubObject(SonderetikettenSubObjectName);

        return appSpecificSonderetikettenProperties is { Count: > 0 } &&
               (sonderetikettenAsAdditionalProperties == null || sonderetikettenAsAdditionalProperties.Count == 0);
    }
}

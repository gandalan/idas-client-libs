using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Util;
/// <summary>
/// Helper methods to get and set metadata to IDTOWithApplicationSpecificProperties.
/// </summary>
public static class AppSecificPropertiesMetadataExtensions
{
    public const string MetadataKey = "$METADATA";
    private const string IsPublicKey = "IsPublic";

    public static bool HasPublicAppSepcificProperties(this IDTOWithApplicationSpecificProperties dto) =>
        dto.GetMetadata().TryGetValue(IsPublicKey, out var isPublic) && (bool)isPublic;

    public static void MakeAppSpecificPropertiesPublic(this IDTOWithApplicationSpecificProperties dto) =>
        dto.AddMetadata(IsPublicKey, true);

    public static PropertyValueCollection GetMetadata(this IDTOWithApplicationSpecificProperties dto) =>
        dto?.ApplicationSpecificProperties?.TryGetValue(MetadataKey, out var metadata) == true ? metadata : [];

    public static void AddMetadata(this IDTOWithApplicationSpecificProperties dto, string key, object value)
    {
        var metadata = dto.GetMetadata() ?? [];
        metadata[key] = value;
        dto.ApplicationSpecificProperties[MetadataKey] = metadata;
    }

    public static void SetIsPublicInMetadata(this Dictionary<string, PropertyValueCollection> dictionary)
    {
        var metadata = dictionary.TryGetValue(MetadataKey, out var m) ? m : [];
        metadata[IsPublicKey] = true;
        dictionary[MetadataKey] = metadata;
    }
}

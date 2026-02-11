using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.DTO;

public class ResourceResolution
{
    public bool Found { get; set; }
    public string Path { get; set; }
}

public class ResourceEntry
{
    [JsonProperty(nameof(GueltigAb))]
    public DateTime GueltigAb { get; set; }
    [JsonProperty(nameof(Pfad))]
    public string Pfad { get; set; }
}

public class ResourceRegistry
{
    [JsonProperty(nameof(Version))]
    public string Version { get; set; }
    [JsonProperty(nameof(Ressourcen))]
    public Dictionary<string, Dictionary<string, List<ResourceEntry>>> Ressourcen { get; set; }
}

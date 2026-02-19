using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class ResourceResolution
{
    public bool Found { get; set; }
    public string Path { get; set; }
}

public class ResourceEntry
{
    public DateTime GueltigAb { get; set; }
    public string Pfad { get; set; }
}

public class ResourceRegistry
{
    public string Version { get; set; }
    public Dictionary<string, Dictionary<string, List<ResourceEntry>>> Ressourcen { get; set; }
}

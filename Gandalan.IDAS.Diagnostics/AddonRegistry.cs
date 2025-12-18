using System.Collections.Generic;

namespace Gandalan.IDAS.Diagnostics;

/// <summary>
/// Registry Klasse for Addons
/// </summary>
public static class AddonRegistry
{
    //TBD: flesh this out to with proper logic to register addons?
    /// <summary>
    /// Liste von installierten Addons (zur Diagnose)
    /// </summary>
    public static List<string> AddonPackages { get; set; } = [];
}

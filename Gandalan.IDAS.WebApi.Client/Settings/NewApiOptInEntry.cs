using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.Settings;

/// <summary>
/// Represents an API endpoint configuration for opting into the new backend API.
/// </summary>
public class NewApiOptInEntry
{
    /// <summary>
    /// The API endpoint path (e.g., "/api/VorgangListe").
    /// </summary>
    public string Endpoint { get; set; }

    /// <summary>
    /// List of HTTP methods allowed for this endpoint (e.g., ["GET", "POST"]).
    /// If null or empty, all methods are allowed.
    /// </summary>
    public List<string> Methods { get; set; }
}

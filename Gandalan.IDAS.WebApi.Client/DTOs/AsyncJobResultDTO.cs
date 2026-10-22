using System;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Status-Antwort für asynchron gestartete Backend-Jobs (Stufe 2 Async Job Pattern).
/// </summary>
public class AsyncJobResultDTO
{
    public Guid JobId { get; set; }

    /// <summary>"Queued" | "Running" | "Completed" | "Failed"</summary>
    public string Status { get; set; }

    /// <summary>Fehlertext bei Status "Failed", sonst null.</summary>
    public string Error { get; set; }
}

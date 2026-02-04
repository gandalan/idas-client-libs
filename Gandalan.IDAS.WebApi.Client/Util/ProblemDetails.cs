using System;
using System.Collections.Generic;
using System.Globalization;

using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Util;

/// <summary>
/// NET48  Custom implementation for RFC 7807 - Problem Details for HTTP APIs
/// </summary>
public class ProblemDetails
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("status")]
    public int? Status { get; set; }

    [JsonProperty("detail")]
    public string Detail { get; set; }

    [JsonProperty("instance")]
    public string Instance { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> Extensions { get; set; }

    public bool TryGetResetDateTimeUtc(out DateTime resetDateTimeUtc)
    {
        resetDateTimeUtc = DateTime.MinValue;

        if (Extensions != null &&
            Extensions.TryGetValue("reset", out var resetObj) &&
            resetObj != null &&
            DateTime.TryParse(resetObj.ToString(),
            null,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
            out var resetDatetime))
        {
            resetDateTimeUtc = resetDatetime;
            return true;
        }

        return false;
    }
}

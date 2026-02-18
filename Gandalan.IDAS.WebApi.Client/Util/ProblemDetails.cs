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

        if (Extensions == null)
        {
            return false;
        }

        return TryGetResetFromUnixTimestamp(out resetDateTimeUtc)
            || TryGetResetFromDateTimeString(out resetDateTimeUtc)
            || TryGetResetFromRetryAfter(out resetDateTimeUtc);
    }

    private bool TryGetResetFromUnixTimestamp(out DateTime resetDateTimeUtc)
    {
        resetDateTimeUtc = DateTime.MinValue;

        if (!Extensions.TryGetValue("reset", out var resetObj) || resetObj == null)
        {
            return false;
        }

        if (!long.TryParse(resetObj.ToString(), out var unixTimestamp))
        {
            return false;
        }

        try
        {
            resetDateTimeUtc = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).UtcDateTime;
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool TryGetResetFromDateTimeString(out DateTime resetDateTimeUtc)
    {
        resetDateTimeUtc = DateTime.MinValue;

        if (!Extensions.TryGetValue("reset", out var resetObj) || resetObj == null)
        {
            return false;
        }

        return DateTime.TryParse(
            resetObj.ToString(),
            null,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
            out resetDateTimeUtc);
    }

    private bool TryGetResetFromRetryAfter(out DateTime resetDateTimeUtc)
    {
        resetDateTimeUtc = DateTime.MinValue;

        if (!Extensions.TryGetValue("retryAfter", out var retryAfterObj) || retryAfterObj == null)
        {
            return false;
        }

        if (!int.TryParse(retryAfterObj.ToString(), out var retryAfterSeconds) || retryAfterSeconds <= 0)
        {
            return false;
        }

        resetDateTimeUtc = DateTime.UtcNow.AddSeconds(retryAfterSeconds);
        return true;
    }
}

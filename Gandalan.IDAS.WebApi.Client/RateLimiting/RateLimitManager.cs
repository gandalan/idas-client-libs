using System;
using System.Collections.Concurrent;

namespace Gandalan.IDAS.WebApi.Client.RateLimiting;

public class RateLimitManager
{
    private static readonly ConcurrentDictionary<string, RateLimitState> _rateLimitsByHost = new();

    public static bool IsRateLimited(string baseUrl, out DateTime resetTime)
    {
        if (_rateLimitsByHost.TryGetValue(GetHostKey(baseUrl), out var state))
        {
            if (DateTime.UtcNow < state.ResetTimeUtc)
            {
                resetTime = state.ResetTimeUtc;
                return true;
            }
            // Expired, remove
            _rateLimitsByHost.TryRemove(GetHostKey(baseUrl), out _);
        }
        resetTime = DateTime.MinValue;
        return false;
    }

    public static void SetRateLimited(string baseUrl, DateTime resetTimeUtc)
    {
        var key = GetHostKey(baseUrl);
        _rateLimitsByHost[key] = new RateLimitState
        {
            ResetTimeUtc = resetTimeUtc,
            ActivatedAt = DateTime.UtcNow
        };
    }

    private static string GetHostKey(string baseUrl)
        => new Uri(baseUrl).Host.ToLowerInvariant();
}

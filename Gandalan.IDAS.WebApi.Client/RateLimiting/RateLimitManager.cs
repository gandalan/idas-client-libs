using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.RateLimiting;

public class RateLimitManager
{
    private static readonly ConcurrentDictionary<string, RateLimitState> _rateLimitsByHost = new();
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> _semaphoresByHost = new();

    public static async Task WaitIfRateLimitedAsync(string baseUrl, CancellationToken cancellationToken = default)
    {
        var hostKey = GetHostKey(baseUrl);
        var semaphore = _semaphoresByHost.GetOrAdd(hostKey, _ => new SemaphoreSlim(1, 1));

        await semaphore.WaitAsync(cancellationToken);

        try
        {
            if (_rateLimitsByHost.TryGetValue(hostKey, out var state))
            {
                var now = DateTime.UtcNow;
                if (now < state.ResetTimeUtc)
                {
                    var waitTime = state.ResetTimeUtc - now;
                    await Task.Delay(waitTime, cancellationToken);
                }

                _rateLimitsByHost.TryRemove(hostKey, out _);
            }
        }
        finally
        {
            semaphore.Release();
        }
    }

    public static bool IsRateLimited(string baseUrl, out DateTime resetTime)
    {
        var hostKey = GetHostKey(baseUrl);

        if (_rateLimitsByHost.TryGetValue(hostKey, out var state))
        {
            if (DateTime.UtcNow < state.ResetTimeUtc)
            {
                resetTime = state.ResetTimeUtc;
                return true;
            }

            _rateLimitsByHost.TryRemove(hostKey, out _);
        }

        resetTime = DateTime.MinValue;
        return false;
    }

    public static void SetRateLimited(string baseUrl, DateTime resetTimeUtc)
    {
        var hostKey = GetHostKey(baseUrl);
        var semaphore = _semaphoresByHost.GetOrAdd(hostKey, _ => new SemaphoreSlim(1, 1));

        semaphore.Wait();
        try
        {
            _rateLimitsByHost[hostKey] = new RateLimitState
            {
                ResetTimeUtc = resetTimeUtc,
                ActivatedAt = DateTime.UtcNow
            };
        }
        finally
        {
            semaphore.Release();
        }
    }

    public static async Task SetRateLimitedAsync(string baseUrl, DateTime resetTimeUtc, CancellationToken cancellationToken = default)
    {
        var hostKey = GetHostKey(baseUrl);
        var semaphore = _semaphoresByHost.GetOrAdd(hostKey, _ => new SemaphoreSlim(1, 1));

        await semaphore.WaitAsync(cancellationToken);
        try
        {
            _rateLimitsByHost[hostKey] = new RateLimitState
            {
                ResetTimeUtc = resetTimeUtc,
                ActivatedAt = DateTime.UtcNow
            };
        }
        finally
        {
            semaphore.Release();
        }
    }

    public static void CleanupExpiredLimits()
    {
        var now = DateTime.UtcNow;
        var expiredKeys = _rateLimitsByHost
            .Where(kvp => kvp.Value.ResetTimeUtc <= now)
            .Select(kvp => kvp.Key)
            .ToList();

        foreach (var key in expiredKeys)
        {
            _rateLimitsByHost.TryRemove(key, out _);
        }
    }

    private static string GetHostKey(string baseUrl)
        => new Uri(baseUrl).Host.ToLowerInvariant();
}

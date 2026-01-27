using System;

namespace Gandalan.IDAS.WebApi.Client.RateLimiting;

internal sealed class RateLimitState
{
    public DateTime ResetTimeUtc { get; set; }
    public DateTime ActivatedAt { get; set; }
}

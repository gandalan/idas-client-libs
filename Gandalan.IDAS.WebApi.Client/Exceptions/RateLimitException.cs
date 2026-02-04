using System;
using System.Net;
using Gandalan.IDAS.Web;

namespace Gandalan.IDAS.WebApi.Client.Exceptions;

public class RateLimitException : ApiException
{
    public DateTime RetryAfterUtc { get; } = DateTime.UtcNow.AddSeconds(-1);

    public string DetailedMessage { get; }

    public RateLimitException(string message, DateTime resetTimeUtc, Exception innerException = null)
        : base(message, innerException)
    {
        RetryAfterUtc = resetTimeUtc;
        StatusCode = (HttpStatusCode)429;

        DetailedMessage = BuildDetailedMessage(resetTimeUtc);
    }

    public RateLimitException(DateTime resetTimeUtc, Exception innerException = null)
        : this($"Rate limit exceeded. Connection blocked until {resetTimeUtc:O} UTC", resetTimeUtc, innerException)
    {
    }

    public RateLimitException()
        : base("Rate limit exceeded")
    {
        RetryAfterUtc = DateTime.UtcNow.AddMinutes(1);
        StatusCode = (HttpStatusCode)429;
        DetailedMessage = "Rate limit exceeded. Connection temporarily restricted.";
    }

    public RateLimitException(string message)
        : base(message)
    {
        RetryAfterUtc = DateTime.UtcNow.AddMinutes(1);
        StatusCode = (HttpStatusCode)429;
        DetailedMessage = message;
    }

    public RateLimitException(string message, Exception innerException)
        : base(message, innerException)
    {
        RetryAfterUtc = DateTime.UtcNow.AddMinutes(1);
        StatusCode = (HttpStatusCode)429;
        DetailedMessage = message;
    }

    private static string BuildDetailedMessage(DateTime resetTimeUtc)
    {
        var secondsRemaining = Math.Max(0, (resetTimeUtc - DateTime.UtcNow).TotalSeconds);
        var baseMessage = $"Rate limit active. Requests blocked until {resetTimeUtc:O} UTC (in {secondsRemaining:F0} seconds)";
        return baseMessage;
    }
}

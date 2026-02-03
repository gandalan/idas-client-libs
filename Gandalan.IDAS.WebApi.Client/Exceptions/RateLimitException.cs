using System;
using System.Net;
using Gandalan.IDAS.Web;

namespace Gandalan.IDAS.WebApi.Client.Exceptions;

public class RateLimitException : ApiException
{
    public Guid? MandantGuid { get; }
    public DateTime RetryAfterUtc { get; } = DateTime.UtcNow.AddSeconds(-1);
    public string Host { get; }
    public TimeSpan RetryAfterInterval
        => RetryAfterUtc > DateTime.UtcNow ? RetryAfterUtc - DateTime.UtcNow : TimeSpan.Zero;

    public string DetailedMessage { get; }

    public RateLimitException(string message, DateTime resetTimeUtc, Exception innerException = null, Guid? mandantGuid = null, string host = null)
        : base(message, innerException)
    {
        RetryAfterUtc = resetTimeUtc;
        MandantGuid = mandantGuid;
        Host = host;
        StatusCode = (HttpStatusCode)429;

        DetailedMessage = BuildDetailedMessage(resetTimeUtc, mandantGuid, host);
    }

    public RateLimitException(DateTime resetTimeUtc, Exception innerException = null, Guid? mandantGuid = null, string host = null)
        : this($"Rate limit exceeded. Connection blocked until {resetTimeUtc:O} UTC", resetTimeUtc, innerException, mandantGuid, host)
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

    private static string BuildDetailedMessage(DateTime resetTimeUtc, Guid? mandantGuid, string host)
    {
        var secondsRemaining = Math.Max(0, (resetTimeUtc - DateTime.UtcNow).TotalSeconds);
        var baseMessage = $"Rate limit active. Requests blocked until {resetTimeUtc:O} UTC (in {secondsRemaining:F0} seconds)";

        if (!string.IsNullOrWhiteSpace(host))
        {
            baseMessage = $"Rate limit active for host '{host}'. Requests blocked until {resetTimeUtc:O} UTC (in {secondsRemaining:F0} seconds)";
        }

        if (mandantGuid.HasValue && mandantGuid.Value != Guid.Empty)
        {
            baseMessage += $" [Mandant: {mandantGuid.Value}]";
        }

        return baseMessage;
    }
}

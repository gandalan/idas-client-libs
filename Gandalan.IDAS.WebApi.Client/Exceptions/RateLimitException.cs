using System;
using System.Net;

using Gandalan.IDAS.Web;

namespace Gandalan.IDAS.WebApi.Client.Exceptions;

public class RateLimitException(string message, DateTime resetTimeUtc) : ApiException(message, (HttpStatusCode)429)
{
    public DateTime ResetTimeUtc { get; } = resetTimeUtc;
    public TimeSpan RetryAfter => ResetTimeUtc - DateTime.UtcNow;
}

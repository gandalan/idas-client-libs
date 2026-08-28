using System;
using System.Net;

using Gandalan.IDAS.WebApi.Client.Util;

using Newtonsoft.Json;

namespace Gandalan.IDAS.Web;

[Serializable]
public class ApiException : Exception
{
    public string Payload { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public string ExceptionString { get; set; }

    public ProblemDetails ProblemDetails { get; set; }

    /// <summary>
    /// Application-Insights-Operation-Id des fehlgeschlagenen Requests, sofern das Backend sie
    /// mitgeliefert hat (Header <c>X-Gdl-OperationId</c> oder ProblemDetails-Extension
    /// <c>operationId</c>). Damit lässt sich der Fehler in der Telemetrie nachschlagen:
    /// <c>union requests, exceptions, traces | where operation_Id == "..."</c>.
    /// </summary>
    public string OperationId { get; set; }

    public ApiException()
    {
    }

    public ApiException(string message) : base(message)
    {
    }

    public ApiException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public ApiException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ApiException(string message, ProblemDetails problemDetails) : base(message)
    {
        StatusCode = ((HttpStatusCode?)problemDetails?.Status) ?? HttpStatusCode.InternalServerError;
        ProblemDetails = problemDetails;
    }

    public ApiException(string message, HttpStatusCode statusCode, ProblemDetails problemDetails) : base(message)
    {
        StatusCode = statusCode;
        ProblemDetails = problemDetails;
    }

    public ApiException(string message, HttpStatusCode statusCode, Exception innerException, ProblemDetails problemDetails, object payload) : base(message, innerException)
    {
        StatusCode = statusCode;
        ProblemDetails = problemDetails;
        Payload = JsonConvert.SerializeObject(payload);
    }

    public ApiException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
    {
        StatusCode = statusCode;
    }

    public ApiException(string message, object payload) : base(message)
    {
        Payload = JsonConvert.SerializeObject(payload);
    }

    public ApiException(string message, HttpStatusCode statusCode, object payload) : base(message)
    {
        StatusCode = statusCode;
        Payload = JsonConvert.SerializeObject(payload);
    }

    public ApiException(string message, HttpStatusCode statusCode, ProblemDetails problemDetails, object payload) : base(message)
    {
        StatusCode = statusCode;
        ProblemDetails = problemDetails;
        Payload = JsonConvert.SerializeObject(payload);
    }

    public ApiException(string message, Exception innerException, object payload) : base(message, innerException)
    {
        Payload = JsonConvert.SerializeObject(payload);
    }

    public ApiException(string message, HttpStatusCode statusCode, Exception innerException, object payload) : base(message, innerException)
    {
        StatusCode = statusCode;
        Payload = JsonConvert.SerializeObject(payload);
    }

    public ApiException(string message, HttpStatusCode statusCode, Exception innerException, ProblemDetails problemDetails) : base(message, innerException)
    {
        StatusCode = statusCode;
        ProblemDetails = problemDetails;
    }
}

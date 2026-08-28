namespace Gandalan.IDAS.WebApi.Client.Constants;

/// <summary>
/// Header-Namen, die zwischen Client und IDAS-Backend vereinbart sind.
/// </summary>
public static class ApiHeaderNames
{
    /// <summary>
    /// Response-Header mit der Application-Insights-Operation-Id des Requests. Wird vom Backend nur
    /// bei Fehler-Responses gesetzt (siehe <c>Gandalan.IDAS.WebApi.AppInsights.TelemetryOperationId</c>)
    /// und landet über <see cref="Gandalan.IDAS.Web.ApiException.OperationId"/> im Fehlerbericht.
    /// </summary>
    public const string OperationId = "X-Gdl-OperationId";

    /// <summary>
    /// Name der ProblemDetails-Extension, unter der das Backend dieselbe Operation-Id im Body mitgibt.
    /// </summary>
    public const string OperationIdProblemDetailsExtension = "operationId";
}

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Intercepts non-success HTTP responses, pre-reads the response body, and enriches
/// the resulting <see cref="HttpRequestException"/> with URL, status code, and response
/// content in <see cref="Exception.Data"/> so that upstream callers (e.g.
/// <c>WebRoutinenBase.TranslateException</c>) can produce meaningful <c>ApiException</c>
/// instances without manual per-method boilerplate.
/// </summary>
internal sealed class ErrorEnrichmentHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = null;
        string responseContent = null;
        try
        {
            response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return response;

            // Pre-read the response body so it is available for exception enrichment.
            responseContent =
#if NET5_0_OR_GREATER
                await response.Content.ReadAsStringAsync(cancellationToken);
#else
                await response.Content.ReadAsStringAsync();
#endif

            response.EnsureSuccessStatusCode(); // always throws here since !IsSuccessStatusCode
            return response; // unreachable, satisfies compiler
        }
        catch (Exception ex) when (!ex.Data.Contains("URL"))
        {
            ex.Data["URL"] = request.RequestUri?.ToString();
            ex.Data["StatusCode"] = response?.StatusCode ?? HttpStatusCode.InternalServerError;
            if (!string.IsNullOrWhiteSpace(responseContent))
                ex.Data["Response"] = responseContent;
            throw;
        }
    }
}

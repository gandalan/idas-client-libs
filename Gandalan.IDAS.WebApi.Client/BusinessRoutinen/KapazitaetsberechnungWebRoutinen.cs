using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class KapazitaetsberechnungWebRoutinen : WebRoutinenBase
{
    public KapazitaetsberechnungWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<Dictionary<Guid, decimal?>> GetKapazitaetAsync(List<Guid> positionGuids)
        => await PostAsync<Dictionary<Guid, decimal?>>("Kapaziaetsberechnung/GetKapaziaet", positionGuids);
    public async Task CalculateKapazitaetForFunctionAsync(Guid positionGuid, long mandantID)
        => await PostAsync($"Kapaziaetsberechnung/RunKapBerechnung?id={positionGuid}&mandantId={mandantID}", null, skipAuth: true);

    /// <summary>
    /// Startet die Kapazitätsberechnung im Backend mit Callback-URL.
    /// Das Backend sendet das Ergebnis per POST an die callbackUrl, sobald die Berechnung abgeschlossen ist.
    /// </summary>
    public async Task StartKapBerechnungWithCallbackAsync(Guid positionGuid, long mandantId, string callbackUrl)
        => await PostAsync($"Kapaziaetsberechnung/RunKapBerechnungWithCallback?id={positionGuid}&mandantId={mandantId}",
            new KapBerechnungCallbackRequest { CallbackUrl = callbackUrl }, skipAuth: true);

    /// <summary>
    /// Startet die Kapazitätsberechnung im Backend als Batch mit Callback-URL.
    /// Das Backend verarbeitet alle Positionen und sendet das aggregierte Ergebnis
    /// per POST an die callbackUrl.
    /// </summary>
    public async Task StartKapBerechnungBatchWithCallbackAsync(
        List<KapBerechnungPosition> positions, string callbackUrl)
        => await PostAsync("Kapaziaetsberechnung/RunKapBerechnungBatchWithCallback",
            new KapBerechnungBatchCallbackRequest { Positions = positions, CallbackUrl = callbackUrl },
            skipAuth: true);

    public async Task CalculateKapazitaetForAVAsync(List<Guid> avPositionGuids, long mandantID)
        => await PostAsync($"Kapaziaetsberechnung/RunKapBerechnungForAV?mandantId={mandantID}", avPositionGuids, skipAuth: true);
    public async Task CalculateItemsAsync()
        => await PostAsync("Kapaziaetsberechnung/CalculateItems", null);

    /// <summary>
    /// Startet den CalculateItems-Job asynchron. Gibt sofort 202 Accepted + JobId zurück.
    /// </summary>
    public async Task<AsyncJobResultDTO> StartCalculateItemsAsync()
        => await PostAsync<AsyncJobResultDTO>("Kapaziaetsberechnung/CalculateItems/Start", null);

    /// <summary>
    /// Fragt den Status eines laufenden CalculateItems-Jobs ab.
    /// </summary>
    public async Task<AsyncJobResultDTO> GetCalculateItemsStatusAsync(Guid jobId)
        => await GetAsync<AsyncJobResultDTO>($"Kapaziaetsberechnung/CalculateItems/Status/{jobId}");

    /// <summary>
    /// Startet den CalculateItems-Bulk-Job im Backend mit Callback-URL.
    /// Das Backend sendet das Ergebnis per POST an die callbackUrl, sobald der Job
    /// abgeschlossen (oder fehlgeschlagen) ist.
    /// </summary>
    public async Task StartCalculateItemsWithCallbackAsync(string callbackUrl)
        => await PostAsync("Kapaziaetsberechnung/CalculateItems/StartWithCallback",
            new KapBerechnungCallbackRequest { CallbackUrl = callbackUrl }, skipAuth: true);
}

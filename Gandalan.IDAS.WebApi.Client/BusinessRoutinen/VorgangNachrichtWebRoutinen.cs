using System;
using System.Net.Http;
using System.Threading.Tasks;

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

/// <summary>
/// Client-Wrapper für Nachrichten zu einem Vorgang und deren Anhänge. Nachrichten sind
/// mandantenübergreifend gültig und werden über eine Junction-Tabelle mit dem jeweiligen
/// Vorgang (und damit dessen Mandant) verknüpft.
/// </summary>
public class VorgangNachrichtWebRoutinen : WebRoutinenBase
{
    public VorgangNachrichtWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    /// <summary>
    /// Lädt alle Nachrichten zu einem Vorgang.
    /// </summary>
    public async Task<VorgangNachrichtDTO[]> GetByVorgangAsync(Guid vorgangGuid)
        => await GetAsync<VorgangNachrichtDTO[]>($"VorgangNachricht/{vorgangGuid}");

    /// <summary>
    /// Speichert eine (neue oder geänderte) Nachricht und liefert sie mit gesetzter VorgangNachrichtGuid zurück.
    /// </summary>
    public async Task<VorgangNachrichtDTO> SendeNachrichtAsync(VorgangNachrichtDTO nachricht)
        => await PutAsync<VorgangNachrichtDTO>("VorgangNachricht", nachricht);

    /// <summary>
    /// Verknüpft eine vorhandene Nachricht mit einem Vorgang in einem Mandanten. Der Server liest
    /// alle drei Werte aus der Query, ein Body wird nicht ausgewertet; PostAsync(uri, null) würde
    /// trotzdem das JSON-Literal "null" als Body serialisieren und mitsenden, daher wird hier
    /// stattdessen PostDataAsync mit einem leeren Byte-Array verwendet.
    /// </summary>
    public async Task ConnectAsync(Guid nachrichtGuid, Guid mandantGuid, Guid vorgangGuid)
        => await PostDataAsync($"VorgangNachricht/Connect?nachrichtGuid={nachrichtGuid}&mandantGuid={mandantGuid}&vorgangGuid={vorgangGuid}", Array.Empty<byte>());

    /// <summary>
    /// Lädt die Datei-Bytes eines Nachrichtenanhangs.
    /// </summary>
    public async Task<byte[]> GetAnhangAsync(Guid anhangGuid)
        => await GetDataAsync($"VorgangNachrichtAnhang/{anhangGuid}");

    /// <summary>
    /// Lädt eine Datei als Anhang zu einer Nachricht hoch. Größen- und Dateityp-Prüfung erfolgen
    /// serverseitig, um keine Doppelpflege der Validierung zu riskieren.
    /// </summary>
    public async Task UploadAnhangAsync(Guid nachrichtGuid, string fileName, byte[] data)
    {
        if (data == null || data.Length == 0)
        {
            throw new ArgumentException("Datei darf nicht leer sein.", nameof(data));
        }

        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("Dateiname darf nicht leer sein.", nameof(fileName));
        }

        using var content = new MultipartFormDataContent();
        var fileContent = new ByteArrayContent(data);
        content.Add(fileContent, "file", fileName);

        await PostDataAsync($"VorgangNachrichtAnhang/{nachrichtGuid}", content);
    }

    /// <summary>
    /// Löscht einen Nachrichtenanhang (Datenbank-Zeile und Blob).
    /// </summary>
    public async Task DeleteAnhangAsync(Guid anhangGuid)
        => await DeleteAsync($"VorgangNachrichtAnhang/{anhangGuid}");
}

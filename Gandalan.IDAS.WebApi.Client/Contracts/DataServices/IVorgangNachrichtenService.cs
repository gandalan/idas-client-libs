using System;
using System.Threading.Tasks;

using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.DataServices;

/// <summary>
/// Zugriff auf Nachrichten zu einem Vorgang und deren Anhänge.
/// </summary>
public interface IVorgangNachrichtenService
{
    /// <summary>
    /// Lädt alle Nachrichten zu einem Vorgang.
    /// </summary>
    Task<VorgangNachrichtDTO[]> GetNachrichtenAsync(Guid vorgangGuid);

    /// <summary>
    /// Legt eine neue Nachricht zu einem Vorgang an. Absender und Gesendet-Zeitpunkt werden von der
    /// Implementierung selbst gesetzt, der Aufrufer liefert nur Betreff und Text.
    /// </summary>
    Task<VorgangNachrichtDTO> AddNachrichtAsync(Guid vorgangGuid, string betreff, string text);

    /// <summary>
    /// Lädt die Datei-Bytes eines Nachrichtenanhangs.
    /// </summary>
    Task<byte[]> GetAnhangAsync(Guid anhangGuid);

    /// <summary>
    /// Lädt eine Datei als Anhang zu einer Nachricht hoch.
    /// </summary>
    Task UploadAnhangAsync(Guid nachrichtGuid, string fileName, byte[] data);

    /// <summary>
    /// Löscht einen Nachrichtenanhang.
    /// </summary>
    Task DeleteAnhangAsync(Guid anhangGuid);
}

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Handlers;

/// <summary>
/// Umhüllt den Antwort-Content, zählt die gelesenen Body-Bytes und meldet den Request genau einmal an den
/// <see cref="HttpTimingMonitor"/>, sobald der Body vollständig gelesen, beim Lesen abgebrochen oder ungelesen verworfen wurde.
/// Nötig, weil <see cref="HttpClient"/> den Body erst nach der Handler-Pipeline puffert und die automatische
/// Dekompression den Content-Length-Header entfernt.
/// </summary>
internal sealed class ZaehlenderHttpContent : HttpContent
{
    private const int PUFFER_GROESSE = 81920;

    private readonly HttpContent _inhalt;
    private readonly HttpRequestMessage _request;
    private readonly HttpResponseMessage _response;
    private readonly Stopwatch _stoppuhr;
    private long _gelesen;
    private int _gemeldet;

    public ZaehlenderHttpContent(HttpContent inhalt, HttpRequestMessage request, HttpResponseMessage response, Stopwatch stoppuhr)
    {
        _inhalt = inhalt;
        _request = request;
        _response = response;
        _stoppuhr = stoppuhr;
        uebernimmHeader();
    }

    protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        => uebertrageAsync(stream, CancellationToken.None);

#if NET5_0_OR_GREATER
    protected override Task SerializeToStreamAsync(Stream stream, TransportContext context, CancellationToken cancellationToken)
        => uebertrageAsync(stream, cancellationToken);
#endif

    protected override bool TryComputeLength(out long length)
    {
        var laenge = _inhalt.Headers.ContentLength;
        length = laenge ?? 0;
        return laenge.HasValue;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            melde(null);
            _inhalt.Dispose();
        }

        base.Dispose(disposing);
    }

    private void uebernimmHeader()
    {
        foreach (var header in _inhalt.Headers)
            Headers.TryAddWithoutValidation(header.Key, header.Value);
    }

    private async Task uebertrageAsync(Stream ziel, CancellationToken cancellationToken)
    {
        try
        {
            using var quelle = await leseInhaltAsync(cancellationToken).ConfigureAwait(false);
            await kopiereZaehlendAsync(quelle, ziel, cancellationToken).ConfigureAwait(false);
            melde(null);
        }
        catch (Exception ex)
        {
            melde(ex);
            throw;
        }
    }

#if NET5_0_OR_GREATER
    private Task<Stream> leseInhaltAsync(CancellationToken cancellationToken)
        => _inhalt.ReadAsStreamAsync(cancellationToken);
#else
    private Task<Stream> leseInhaltAsync(CancellationToken cancellationToken)
        => _inhalt.ReadAsStreamAsync();
#endif

    private async Task kopiereZaehlendAsync(Stream quelle, Stream ziel, CancellationToken cancellationToken)
    {
        var puffer = new byte[PUFFER_GROESSE];
        int anzahl;
        while ((anzahl = await leseBlockAsync(quelle, puffer, cancellationToken).ConfigureAwait(false)) > 0)
        {
            await schreibeBlockAsync(ziel, puffer, anzahl, cancellationToken).ConfigureAwait(false);
            Interlocked.Add(ref _gelesen, anzahl);
        }
    }

#if NET5_0_OR_GREATER
    private static ValueTask<int> leseBlockAsync(Stream quelle, byte[] puffer, CancellationToken cancellationToken)
        => quelle.ReadAsync(puffer.AsMemory(), cancellationToken);

    private static ValueTask schreibeBlockAsync(Stream ziel, byte[] puffer, int anzahl, CancellationToken cancellationToken)
        => ziel.WriteAsync(puffer.AsMemory(0, anzahl), cancellationToken);
#else
    private static Task<int> leseBlockAsync(Stream quelle, byte[] puffer, CancellationToken cancellationToken)
        => quelle.ReadAsync(puffer, 0, puffer.Length, cancellationToken);

    private static Task schreibeBlockAsync(Stream ziel, byte[] puffer, int anzahl, CancellationToken cancellationToken)
        => ziel.WriteAsync(puffer, 0, anzahl, cancellationToken);
#endif

    private void melde(Exception fehler)
    {
        if (Interlocked.Exchange(ref _gemeldet, 1) == 1)
            return;

        HttpTimingMonitor.Observe(_request, _response, _stoppuhr.ElapsedMilliseconds, Interlocked.Read(ref _gelesen), fehler);
    }
}

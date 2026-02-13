#nullable enable
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.SSO;

public class SsoCallbackServer : IDisposable
{
    private readonly HttpListener _listener;
    private readonly TaskCompletionSource<string> _tokenSource;
    private readonly CancellationTokenSource _timeoutSource;
    private bool _disposed;

    public string CallbackUrl { get; }

    public SsoCallbackServer(int timeoutSeconds = 120)
    {
        int port = GetFreePort();
        CallbackUrl = $"http://127.0.0.1:{port}/callback";

        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://127.0.0.1:{port}/callback/");

        _tokenSource = new TaskCompletionSource<string>();
        _timeoutSource = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds));

        _timeoutSource.Token.Register(() => _tokenSource.TrySetCanceled());
    }

    public async Task StartAsync()
    {
        _listener.Start();
        _ = HandleRequestAsync();
    }

    public Task<string> WaitForTokenAsync(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.CanBeCanceled)
        {
            cancellationToken.Register(() => _tokenSource.TrySetCanceled());
        }
        return _tokenSource.Task;
    }

    private async Task HandleRequestAsync()
    {
        try
        {
            var context = await _listener.GetContextAsync();
            var request = context.Request;
            var response = context.Response;

            if (request.HttpMethod == "GET" && request.QueryString["token"] is string token)
            {
                _tokenSource.TrySetResult(token);

                string html = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head><body><h1>Login erfolgreich!</h1><p>Sie können dieses Fenster jetzt schließen.</p></body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(html);

                response.StatusCode = 200;
                response.ContentType = "text/html; charset=utf-8";
                response.ContentLength64 = buffer.Length;
#pragma warning disable CA1835 // Prefer the Memory-based overloads
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
#pragma warning restore CA1835
            }
            else
            {
                response.StatusCode = 400;
            }

            response.Close();
        }
        catch (HttpListenerException) when (_disposed)
        {
        }
        catch (Exception ex)
        {
            _tokenSource.TrySetException(ex);
        }
        finally
        {
            Dispose();
        }
    }

    private static int GetFreePort()
    {
        TcpListener? listener = null;
        try
        {
            listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
        finally
        {
            listener?.Stop();
        }
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        _timeoutSource?.Cancel();
        _timeoutSource?.Dispose();

        try
        {
            _listener?.Stop();
            _listener?.Close();
        }
        catch { }

        if (!_tokenSource.Task.IsCompleted)
        {
            _tokenSource.TrySetCanceled();
        }
    }
}

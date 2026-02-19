#nullable enable
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.SSO;

public class SsoCallbackServer : IDisposable
{
    private readonly TcpListener _listener;
    private readonly TaskCompletionSource<string> _tokenSource;
    private readonly CancellationTokenSource _timeoutSource;
    private readonly CancellationTokenSource _disposeSource;
    private bool _disposed;
    private readonly int _port;

    public string CallbackUrl { get; }

    public SsoCallbackServer(int timeoutSeconds = 120)
    {
        _port = GetFreePort();
        CallbackUrl = $"http://127.0.0.1:{_port}/callback/";

        _listener = new TcpListener(IPAddress.Loopback, _port);

        _tokenSource = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
        _timeoutSource = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds));
        _disposeSource = new CancellationTokenSource();

        // Register timeout cancellation
        _timeoutSource.Token.Register(() => _tokenSource.TrySetCanceled());
    }

    public Task StartAsync()
    {
        _listener.Start();
        _ = HandleRequestsAsync();
        return Task.CompletedTask;
    }

    public Task<string> WaitForTokenAsync(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.CanBeCanceled)
        {
            cancellationToken.Register(() => _tokenSource.TrySetCanceled());
        }
        return _tokenSource.Task;
    }

    private async Task HandleRequestsAsync()
    {
        try
        {
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                _timeoutSource.Token, _disposeSource.Token);

            while (!_disposed && !_tokenSource.Task.IsCompleted)
            {
                try
                {
                    // Accept client connection with cancellation support
                    var clientTask = _listener.AcceptTcpClientAsync();
                    
                    // Wait for either a connection or cancellation
                    var completedTask = await Task.WhenAny(
                        clientTask, 
                        Task.Delay(Timeout.Infinite, linkedCts.Token));

                    if (completedTask != clientTask)
                    {
                        // Cancellation requested
                        break;
                    }

                    var client = await clientTask;
                    _ = HandleClientAsync(client);
                }
                catch (OperationCanceledException)
                {
                    // Expected when cancelled
                    break;
                }
                catch (ObjectDisposedException)
                {
                    // Listener disposed
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in SSO callback server: {ex.Message}");
            _tokenSource.TrySetException(ex);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        try
        {
            using (client)
            using (var stream = client.GetStream())
            {
                // Set read timeout to prevent hanging
                client.ReceiveTimeout = 5000;
                client.SendTimeout = 5000;

                // Read the HTTP request
                var requestData = await ReadRequestAsync(stream);
                if (string.IsNullOrEmpty(requestData))
                {
                    await SendResponseAsync(stream, 400, "Bad Request");
                    return;
                }

                // Parse the request line
                var lines = requestData.Split(new[] { "\r\n" }, StringSplitOptions.None);
                if (lines.Length == 0)
                {
                    await SendResponseAsync(stream, 400, "Bad Request");
                    return;
                }

                var requestLine = lines[0];
                var parts = requestLine.Split(' ');
                if (parts.Length < 2)
                {
                    await SendResponseAsync(stream, 400, "Bad Request");
                    return;
                }

                var method = parts[0];
                var path = parts[1];

                // Only handle GET requests to /callback/
                if (method != "GET" || !path.StartsWith("/callback/", StringComparison.OrdinalIgnoreCase))
                {
                    await SendResponseAsync(stream, 404, "Not Found");
                    return;
                }

                // Parse query string
                var queryString = ParseQueryString(path);
                var token = queryString["token"];

                if (!string.IsNullOrEmpty(token))
                {
                    _tokenSource.TrySetResult(token);

                    string html = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"">
    <title>Login erfolgreich</title>
    <style>
        body { font-family: Arial, sans-serif; text-align: center; padding: 50px; }
        h1 { color: #4CAF50; }
    </style>
</head>
<body>
    <h1>Login erfolgreich!</h1>
    <p>Sie können dieses Fenster jetzt schließen.</p>
    <script>window.close();</script>
</body>
</html>";

                    await SendResponseAsync(stream, 200, "OK", html, "text/html; charset=utf-8");
                }
                else
                {
                    await SendResponseAsync(stream, 400, "Bad Request - Missing token");
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error handling SSO client: {ex.Message}");
        }
        finally
        {
            // Dispose the server after handling the first valid request or error
            if (!_disposed && _tokenSource.Task.IsCompleted)
            {
                Dispose();
            }
        }
    }

    private static async Task<string> ReadRequestAsync(NetworkStream stream)
    {
        var buffer = new byte[4096];
        var sb = new StringBuilder();
        
        try
        {
            // Read with timeout
            var readTask = stream.ReadAsync(buffer, 0, buffer.Length);
            var timeoutTask = Task.Delay(5000);
            
            var completedTask = await Task.WhenAny(readTask, timeoutTask);
            if (completedTask == timeoutTask)
            {
                return string.Empty;
            }

            int bytesRead = await readTask;
            if (bytesRead == 0)
            {
                return string.Empty;
            }

            sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            return sb.ToString();
        }
        catch
        {
            return string.Empty;
        }
    }

    private static async Task SendResponseAsync(NetworkStream stream, int statusCode, string statusText, string? body = null, string? contentType = null)
    {
        var response = new StringBuilder();
        response.AppendLine($"HTTP/1.1 {statusCode} {statusText}");
        
        if (!string.IsNullOrEmpty(body))
        {
            var bodyBytes = Encoding.UTF8.GetBytes(body);
            response.AppendLine($"Content-Type: {contentType}");
            response.AppendLine($"Content-Length: {bodyBytes.Length}");
            response.AppendLine("Connection: close");
            response.AppendLine();
            
            var headerBytes = Encoding.UTF8.GetBytes(response.ToString());
#pragma warning disable CA1835 // Prefer the Memory-based overloads
            await stream.WriteAsync(headerBytes, 0, headerBytes.Length);
            await stream.WriteAsync(bodyBytes, 0, bodyBytes.Length);
#pragma warning restore CA1835
        }
        else
        {
            response.AppendLine("Content-Length: 0");
            response.AppendLine("Connection: close");
            response.AppendLine();
            
            var headerBytes = Encoding.UTF8.GetBytes(response.ToString());
#pragma warning disable CA1835 // Prefer the Memory-based overloads
            await stream.WriteAsync(headerBytes, 0, headerBytes.Length);
#pragma warning restore CA1835
        }
    }

    private static NameValueCollection ParseQueryString(string path)
    {
        var result = new NameValueCollection();
        
        var queryIndex = path.IndexOf('?');
        if (queryIndex < 0 || queryIndex >= path.Length - 1)
        {
            return result;
        }

        var queryString = path.Substring(queryIndex + 1);
        var pairs = queryString.Split('&');

        foreach (var pair in pairs)
        {
            var kv = pair.Split(new[] { '=' }, 2);
            if (kv.Length == 2)
            {
                var key = Uri.UnescapeDataString(kv[0]);
                var value = Uri.UnescapeDataString(kv[1]);
                result.Add(key, value);
            }
            else if (kv.Length == 1)
            {
                result.Add(Uri.UnescapeDataString(kv[0]), string.Empty);
            }
        }

        return result;
    }

    private static int GetFreePort()
    {
        TcpListener? listener = null;
        try
        {
            listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            return port;
        }
        finally
        {
            listener?.Stop();
#if NET5_0_OR_GREATER
            listener?.Dispose();
#endif
        }
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        _disposeSource?.Cancel();
        _disposeSource?.Dispose();
        _timeoutSource?.Cancel();
        _timeoutSource?.Dispose();

        try
        {
            _listener?.Stop();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error disposing TcpListener: {ex.Message}");
        }

        if (!_tokenSource.Task.IsCompleted)
        {
            _tokenSource.TrySetCanceled();
        }
    }
}

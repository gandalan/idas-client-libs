---
sidebar_position: 3
---

# WebApi.Client Guide

The **Gandalan.IDAS.WebApi.Client** library provides a comprehensive REST client for communicating with IDAS APIs. This guide covers the core components and usage patterns.

## Overview

The WebApi.Client library offers:

- **RESTRoutinen** - Low-level HTTP client with JSON serialization
- **BusinessRoutinen** - High-level business logic wrappers
- **Authentication** - Built-in token management
- **Error Handling** - Structured exception hierarchy
- **DTOs** - Type-safe data transfer objects

## RESTRoutinen Class

`RESTRoutinen` is the low-level HTTP client that handles:

- HTTP GET, POST, PUT, DELETE requests
- JSON serialization/deserialization
- Custom headers and authentication
- Response error handling

### Basic Usage

```csharp
using Gandalan.IDAS.Web;

// Create REST client
var restClient = new RESTRoutinen("https://idas.gandalan.de");

// Set custom user agent
restClient.UserAgent = "MyApp/1.0";

// GET request
var data = await restClient.GetAsync<MyDto>("api/Endpoint");

// POST request
var result = await restClient.PostAsync<MyResponse>("api/Endpoint", requestData);

// PUT request
var updated = await restClient.PutAsync<MyResponse>("api/Endpoint", updateData);

// DELETE request
await restClient.DeleteAsync("api/Endpoint/123");
```

### Generic Methods

```csharp
// Get typed response
var dto = await restClient.GetAsync<MyDto>("api/Vorgang/123");

// Get raw string
var json = await restClient.GetAsync("api/Vorgang/123");

// Get binary data
var bytes = await restClient.GetDataAsync("api/File/123");
```

## BusinessRoutinen Pattern

BusinessRoutinen provide a higher-level abstraction over REST operations. They encapsulate business logic and API endpoints.

### Base Class

All business routines inherit from `WebRoutinenBase`:

```csharp
public class WebRoutinenBase
{
    protected IWebApiConfig Settings { get; }
    
    // HTTP methods
    protected Task<T> GetAsync<T>(string uri, ...);
    protected Task<T> PostAsync<T>(string uri, object data, ...);
    protected Task<T> PutAsync<T>(string uri, object data, ...);
    protected Task DeleteAsync(string uri, ...);
    
    // Authentication
    public Task<bool> LoginAsync();
    public Task<UserAuthTokenDTO> RefreshTokenAsync(Guid token);
}
```

### Example: VorgangWebRoutinen

```csharp
using Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class VorgangWebRoutinen : WebRoutinenBase
{
    public VorgangWebRoutinen(IWebApiConfig settings) : base(settings) { }

    // Load list of Vorgänge
    public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(int jahr)
        => await GetAsync<VorgangListItemDTO[]>($"Vorgang/?jahr={jahr}");

    // Load single Vorgang
    public async Task<VorgangDTO> LadeVorgangAsync(Guid vorgangGuid, bool mitKunde)
        => await GetAsync<VorgangDTO>($"Vorgang/{vorgangGuid}?includeKunde={mitKunde}");

    // Save Vorgang
    public async Task<VorgangDTO> SendeVorgangAsync(VorgangDTO vorgang)
        => await PutAsync<VorgangDTO>("Vorgang", vorgang);

    // Change status
    public async Task<VorgangStatusDTO> SetStatusAsync(Guid vorgangGuid, string statusCode)
    {
        var set = new VorgangStatusDTO
        {
            VorgangGuid = vorgangGuid,
            NeuerStatus = statusCode
        };
        return await PutAsync<VorgangStatusDTO>("VorgangStatus", set);
    }
}
```

### Using BusinessRoutinen

```csharp
// Create instance with settings
var settings = new WebApiSettings { /* ... */ };
var vorgangRoutinen = new VorgangWebRoutinen(settings);

// Login (automatic on first request, or explicit)
var loggedIn = await vorgangRoutinen.LoginAsync();

// Load data
var vorgaenge = await vorgangRoutinen.LadeVorgangsListeAsync(2025);
var vorgang = await vorgangRoutinen.LadeVorgangAsync(guid, true);

// Update data
vorgang.Status = "Neu";
var updated = await vorgangRoutinen.SendeVorgangAsync(vorgang);
```

## Available BusinessRoutinen

The library includes many pre-built business routines:

| Routine | Purpose |
|---------|---------|
| `VorgangWebRoutinen` | Business process operations |
| `BelegPositionenWebRoutinen` | Document position operations |
| `KontaktWebRoutinen` | Contact management |
| `ArtikelWebRoutinen` | Article/catalog operations |
| `MaterialWebRoutinen` | Material management |
| `ProduktionWebRoutinen` | Production operations |
| `BenutzerWebRoutinen` | User management |
| `MandantenWebRoutinen` | Tenant operations |
| `SerienWebRoutinen` | Series management |
| `SettingsWebRoutinen` | Configuration settings |

## DTOs Overview

Data Transfer Objects (DTOs) define the structure of data exchanged with the API.

### Key DTO Categories

```
DTOs/
├── Belege/           # Documents (Belege)
├── Benutzer/         # Users and authentication
├── Kontakte/         # Contacts
├── Produktion/       # Production data
├── UI/               # UI configuration
├── Rechnung/         # Invoicing
├── Technik/          # Technical data
└── Filter/           # Filtering
```

### Common DTOs

```csharp
// Business process
public class VorgangDTO
{
    public Guid VorgangGuid { get; set; }
    public long VorgangsNummer { get; set; }
    public string KundeName { get; set; }
    public DateTime BelegDatum { get; set; }
    public string Status { get; set; }
    public List<BelegDTO> Belege { get; set; }
}

// Document
public class BelegDTO
{
    public Guid BelegGuid { get; set; }
    public long BelegNummer { get; set; }
    public BelegArt BelegArt { get; set; }
    public List<BelegPositionDTO> Positionen { get; set; }
}

// Document position
public class BelegPositionDTO
{
    public Guid BelegPositionGuid { get; set; }
    public int LaufendeNummer { get; set; }
    public string ArtikelNummer { get; set; }
    public decimal Menge { get; set; }
    public decimal Einzelpreis { get; set; }
}
```

## Error Handling

The library provides structured exception handling:

### Exception Hierarchy

```
Exception
├── ApiException
│   ├── ApiUnauthorizedException
│   └── RateLimitException
└── InvalidDateTimeKindException
```

### Handling Errors

```csharp
try
{
    var result = await vorgangRoutinen.LadeVorgangAsync(guid);
}
catch (ApiUnauthorizedException)
{
    // Handle authentication failure
    Console.WriteLine("Please check your credentials");
}
catch (RateLimitException ex)
{
    // Handle rate limiting
    Console.WriteLine($"Rate limited. Retry after: {ex.ResetTime}");
}
catch (ApiException ex)
{
    // Handle general API errors
    Console.WriteLine($"API Error: {ex.Message}");
    Console.WriteLine($"Status: {ex.StatusCode}");
    
    if (ex.Data.Contains("URL"))
        Console.WriteLine($"URL: {ex.Data["URL"]}");
    if (ex.Data.Contains("Response"))
        Console.WriteLine($"Response: {ex.Data["Response"]}");
}
```

### Custom Exception Handling

```csharp
// Register global exception handler
WebRoutinenBase.CustomExceptionHandler += (ex) =>
{
    if (ex is ApiUnauthorizedException)
    {
        // Show login dialog
        return true; // Handled
    }
    return false; // Not handled, will be thrown
};
```

## Advanced Configuration

### HttpClientConfig

For advanced scenarios, use `HttpClientConfig`:

```csharp
var config = new HttpClientConfig
{
    BaseUrl = "https://idas.gandalan.de",
    UseCompression = true,
    UserAgent = "MyApp/1.0",
    AdditionalHeaders = new Dictionary<string, string>
    {
        ["X-Custom-Header"] = "value"
    }
};

var restClient = new RESTRoutinen(config);
```

### API Versioning

```csharp
// Use specific API version
var result = await restClient.GetAsync<MyDto>("api/Endpoint", version: "2.0");
```

### Skip Authentication

```csharp
// For endpoints that don't require auth
var result = await vorgangRoutinen.GetAsync<MyDto>("api/Public", skipAuth: true);
```

## Best Practices

1. **Reuse BusinessRoutinen instances** - They handle authentication caching
2. **Handle exceptions properly** - Use specific exception types
3. **Use DTOs** - Don't work with raw JSON
4. **Enable compression** - Reduces bandwidth usage
5. **Configure timeouts** - Set appropriate timeouts for your use case

---

For complete API documentation, see the [API Reference](/docs/api/csharp).

---
sidebar_position: 2
---

# Getting Started with C#

This guide will help you get up and running with the IDAS C# Client Libraries in your .NET application.

## Prerequisites

Before you begin, ensure you have the following installed:

### Required

- **.NET 8.0 SDK** or **.NET Framework 4.8 Developer Pack**
  - Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download)

### Optional

- Visual Studio 2022 or JetBrains Rider
- NuGet Package Manager

## Installation

### Step 1: Create a New Project

```bash
# Create a new console application
dotnet new console -n MyIDASApp
cd MyIDASApp

# Or create a WPF application
dotnet new wpf -n MyIDASWpfApp
cd MyIDASWpfApp
```

### Step 2: Add NuGet Packages

```bash
# Core package (required)
dotnet add package Gandalan.IDAS.WebApi.Client

# WPF support (for desktop apps)
dotnet add package Gandalan.IDAS.WebApi.Client.Wpf

# Utilities (optional but recommended)
dotnet add package Gandalan.IDAS.Logging
```

### Step 3: Verify Installation

```bash
dotnet restore
dotnet build
```

## Basic Usage Example

### Configuration (IWebApiConfig)

The `IWebApiConfig` interface defines the configuration needed to connect to IDAS services:

```csharp
using Gandalan.IDAS.WebApi.Client.Settings;

// Create settings
var settings = new WebApiSettings
{
    // API endpoint URL
    Url = "https://idas.gandalan.de",
    
    // Authentication credentials
    UserName = "your-username@company.com",
    Passwort = "your-secure-password",
    
    // Application token (provided by Gandalan)
    AppToken = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
    
    // Optional: Custom user agent
    UserAgent = "MyApp/1.0",
    
    // Optional: Enable compression
    UseCompression = true
};
```

### Authentication Setup

The library handles authentication automatically using the provided credentials:

```csharp
using Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

// Create business routine instance
var vorgangRoutinen = new VorgangWebRoutinen(settings);

// Login is automatic on first request
// Or explicitly check login status
var loginSuccess = await vorgangRoutinen.LoginAsync();

if (loginSuccess)
{
    Console.WriteLine($"Authenticated as: {settings.UserName}");
}
else
{
    Console.WriteLine($"Login failed: {vorgangRoutinen.Status}");
}
```

### Making API Calls

```csharp
using Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

// Create business routine
var vorgangRoutinen = new VorgangWebRoutinen(settings);

// Load a list of business processes
var vorgangsListe = await vorgangRoutinen.LadeVorgangsListeAsync(2025);

foreach (var vorgang in vorgangsListe)
{
    Console.WriteLine($"Vorgang: {vorgang.VorgangsNummer} - {vorgang.KundeName}");
}

// Load a specific business process
var vorgangGuid = Guid.Parse("...");
var vorgang = await vorgangRoutinen.LadeVorgangAsync(vorgangGuid, mitKunde: true);

// Update a business process
vorgang.Status = "Neuer Status";
var updated = await vorgangRoutinen.SendeVorgangAsync(vorgang);
```

### Complete Example

```csharp
using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.BusinessRoutinen;
using Gandalan.IDAS.WebApi.Client.Settings;

class Program
{
    static async Task Main(string[] args)
    {
        // Configure settings
        var settings = new WebApiSettings
        {
            Url = "https://idas.gandalan.de",
            UserName = "user@example.com",
            Passwort = "password",
            AppToken = Guid.Parse("your-app-token")
        };

        try
        {
            // Create business routine
            var vorgangRoutinen = new VorgangWebRoutinen(settings);
            
            // Load business processes for year 2025
            var vorgaenge = await vorgangRoutinen.LadeVorgangsListeAsync(2025);
            
            Console.WriteLine($"Found {vorgaenge.Length} Vorgänge");
            
            foreach (var v in vorgaenge.Take(5))
            {
                Console.WriteLine($"  {v.VorgangsNummer}: {v.KundeName}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
```

## Environment Configuration

For different environments (development, staging, production), you can use `WebApiConfigurations`:

```csharp
// Initialize configurations
await WebApiConfigurations.InitializeAsync(appToken, "Production");

// Get preconfigured settings
var prodSettings = WebApiConfigurations.ByName("Production");
```

## JWT Authentication

For modern applications, JWT authentication is recommended:

```csharp
// Use JwtWebApiSettings for JWT-based auth
var jwtSettings = new JwtWebApiSettings
{
    Url = "https://idas.gandalan.de",
    JwtToken = "your-jwt-token",
    AppToken = Guid.Parse("your-app-token")
};

var vorgangRoutinen = new VorgangWebRoutinen(jwtSettings);
```

## Error Handling

The library provides detailed error information:

```csharp
try
{
    var result = await vorgangRoutinen.LadeVorgangAsync(guid);
}
catch (ApiException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
    Console.WriteLine($"Status Code: {ex.StatusCode}");
    
    if (ex.Data.Contains("URL"))
    {
        Console.WriteLine($"Request URL: {ex.Data["URL"]}");
    }
}
catch (ApiUnauthorizedException ex)
{
    Console.WriteLine("Authentication failed. Please check credentials.");
}
```

## Next Steps

Now that you have the basics working:

- [WebApi.Client Guide](./webapi-client) - Learn more about REST client capabilities
- [Crypto Guide](./crypto) - Learn about encryption and hashing
- [Logging Guide](./logging) - Configure logging for your application
- [Contracts Guide](./contracts) - Understand base classes and patterns

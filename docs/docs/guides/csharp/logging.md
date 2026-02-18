---
sidebar_position: 5
---

# Logging Library Guide

The **Gandalan.IDAS.Logging** library provides a comprehensive logging infrastructure for IDAS applications with support for multiple log levels, contexts, and output targets.

## Overview

The Logging library features:

- **ILogger Interface** - Abstraction for logging implementations
- **L Static Class** - Convenient static methods for logging
- **Log Levels** - Immer, Fehler, Warnung, Info, Diagnose
- **Log Contexts** - Categorize logs by functional area
- **File & Console Output** - Multiple output targets

## ILogger Interface

The `ILogger` interface defines the contract for logging implementations.

```csharp
using Gandalan.IDAS.Logging.Contracts;

public interface ILogger
{
    // Set log file path
    void SetLogDateiPfad(string pfad = null);
    
    // Log a message
    void Log(string message, LogLevel level = LogLevel.Diagnose, 
             LogContext context = LogContext.Allgemein, string sender = null);
    
    // Configure log levels per context
    Dictionary<LogContext, LogLevel> LogLevels { get; set; }
    
    // Event for log string added
    event LogStringAddedDelegate OnLogStringAdded;
}
```

### Using ILogger

```csharp
using Gandalan.IDAS.Logging;
using Gandalan.IDAS.Logging.Contracts;

// Get logger instance
ILogger logger = Logger.GetInstance();

// Set custom log file path
logger.SetLogDateiPfad(@"C:\Logs\myapp.log");

// Log messages
logger.Log("Application started", LogLevel.Info);
logger.Log("Processing order", LogLevel.Diagnose, LogContext.Belege);
logger.Log("Connection failed", LogLevel.Fehler, LogContext.WebApi);
```

## L Static Class

The `L` class provides static methods for convenient logging without managing logger instances.

### Log Levels

```csharp
using Gandalan.IDAS.Logging;

// Always log (critical)
L.Immer("System shutting down");

// Error logging
L.Fehler("Database connection failed");

// Warning logging
L.Warnung("Low disk space");

// Info logging
L.Info("Order processed successfully");

// Diagnostic logging (verbose)
L.Diagnose("Variable x = 42");
```

### Logging Exceptions

```csharp
using Gandalan.IDAS.Logging;

try
{
    // Some operation
    riskyOperation();
}
catch (Exception ex)
{
    // Log exception with message
    L.Fehler(ex, "Operation failed");
    
    // Or just log the exception
    L.Fehler(ex);
}
```

### Using Contexts

```csharp
using Gandalan.IDAS.Logging;

// Log with specific context
L.Info("Loading vorgänge", LogContext.Belege);
L.Info("Rendering PDF", LogContext.Rendering);
L.Warnung("Cache miss", LogContext.AV);
L.Fehler("API call failed", LogContext.WebApi);
```

### Automatic Sender Information

The `L` class automatically captures the calling method name:

```csharp
using Gandalan.IDAS.Logging;

public class OrderService
{
    public void ProcessOrder()
    {
        // Sender will be "ProcessOrder"
        L.Info("Starting order processing");
        
        DoWork();
    }
    
    private void DoWork()
    {
        // Sender will be "DoWork"
        L.Diagnose("Doing work...");
    }
}
```

## Log Levels

| Level | Value | Usage |
|-------|-------|-------|
| Immer | 0 | Always logged, regardless of configuration |
| Fehler | 1 | Errors and exceptions |
| Warnung | 2 | Warnings and potential issues |
| Info | 3 | Informational messages |
| Diagnose | 4 | Detailed diagnostic information |

### Configuring Log Levels

```csharp
using Gandalan.IDAS.Logging;
using Gandalan.IDAS.Logging.Contracts;

var logger = Logger.GetInstance();

// Set minimum level for all contexts
logger.LogLevels[LogContext.Allgemein] = LogLevel.Info;

// Set specific levels for different contexts
logger.LogLevels[LogContext.WebApi] = LogLevel.Diagnose;  // Verbose
logger.LogLevels[LogContext.Belege] = LogLevel.Info;      // Normal
logger.LogLevels[LogContext.Fehler] = LogLevel.Fehler;    // Errors only
```

## Log Contexts

Contexts categorize logs by functional area:

| Context | Description |
|---------|-------------|
| Allgemein | General logging |
| Belegblatt | Document operations |
| Belegposition | Position operations |
| AV | AV (Auftragsvorbereitung) |
| SLK | SLK operations |
| UniDEx | UniDEx operations |
| Adressen | Address management |
| Lager | Warehouse/inventory |
| Statistik | Statistics |
| Rendering | PDF/image rendering |
| Lizenz | Licensing |
| Scripting | Script execution |
| UIModuleManager | UI module management |
| BackendService | Backend services |
| WebApi | Web API calls |
| StammdatenPflege | Master data maintenance |
| Drucken | Printing operations |

## Configuration

### Basic Configuration

```csharp
using Gandalan.IDAS.Logging;

// Configure at application startup
public void ConfigureLogging()
{
    var logger = Logger.GetInstance();
    
    // Set log file location
    logger.SetLogDateiPfad(@"C:\ProgramData\MyApp\Logs\app.log");
    
    // Set default log level
    logger.LogLevels[LogContext.Allgemein] = LogLevel.Info;
    
    // Subscribe to log events
    logger.OnLogStringAdded += (message) =>
    {
        // Custom handling, e.g., send to monitoring service
        monitoringService.SendLog(message);
    };
}
```

### Advanced Configuration

```csharp
using Gandalan.IDAS.Logging;

public class LoggingConfig
{
    public void Configure()
    {
        var logger = Logger.GetInstance();
        
        // Production: Log errors and above
        #if RELEASE
        logger.LogLevels[LogContext.Allgemein] = LogLevel.Fehler;
        logger.LogLevels[LogContext.WebApi] = LogLevel.Warnung;
        #else
        // Debug: Log everything
        logger.LogLevels[LogContext.Allgemein] = LogLevel.Diagnose;
        logger.LogLevels[LogContext.WebApi] = LogLevel.Diagnose;
        #endif
        
        // Specific component logging
        logger.LogLevels[LogContext.Rendering] = LogLevel.Warnung;
        logger.LogLevels[LogContext.Belege] = LogLevel.Info;
    }
}
```

## Code Examples

### Application Startup

```csharp
using System;
using Gandalan.IDAS.Logging;

class Program
{
    static void Main(string[] args)
    {
        // Configure logging
        var logger = Logger.GetInstance();
        logger.SetLogDateiPfad(@"C:\Logs\myapp.log");
        
        L.Immer("========================================");
        L.Immer("Application Starting");
        L.Immer($"Version: {GetVersion()}");
        L.Immer($"Time: {DateTime.Now}");
        L.Immer("========================================");
        
        try
        {
            RunApplication();
        }
        catch (Exception ex)
        {
            L.Fehler(ex, "Fatal error in application");
            throw;
        }
        finally
        {
            L.Immer("Application Exiting");
        }
    }
}
```

### Service with Logging

```csharp
using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Logging;

public class OrderService
{
    public async Task<Order> ProcessOrderAsync(OrderRequest request)
    {
        L.Info($"Processing order for customer: {request.CustomerId}", LogContext.Belege);
        
        try
        {
            // Validate
            L.Diagnose("Validating order request", LogContext.Belege);
            ValidateRequest(request);
            
            // Process
            L.Diagnose("Creating order entity", LogContext.Belege);
            var order = await CreateOrderEntity(request);
            
            // Save
            L.Diagnose("Saving to database", LogContext.Belege);
            await SaveOrder(order);
            
            L.Info($"Order {order.Id} processed successfully", LogContext.Belege);
            return order;
        }
        catch (ValidationException ex)
        {
            L.Warnung($"Order validation failed: {ex.Message}", LogContext.Belege);
            throw;
        }
        catch (Exception ex)
        {
            L.Fehler(ex, $"Failed to process order for customer {request.CustomerId}");
            throw;
        }
    }
}
```

### Web API Logging

```csharp
using Gandalan.IDAS.Logging;

public class ApiClient
{
    public async Task<T> GetAsync<T>(string url)
    {
        L.Diagnose($"GET {url}", LogContext.WebApi);
        
        try
        {
            var response = await _httpClient.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                L.Diagnose($"GET {url} - Success ({response.StatusCode})", LogContext.WebApi);
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                L.Warnung($"GET {url} - Failed ({response.StatusCode})", LogContext.WebApi);
                throw new ApiException($"Request failed: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            L.Fehler(ex, $"GET {url} - Exception", LogContext.WebApi);
            throw;
        }
    }
}
```

### Custom Log Handler

```csharp
using Gandalan.IDAS.Logging;
using Gandalan.IDAS.Logging.Contracts;

public class LogAggregator
{
    private readonly List<string> _recentLogs = new();
    
    public void Initialize()
    {
        var logger = Logger.GetInstance();
        
        logger.OnLogStringAdded += (logMessage) =>
        {
            // Store recent logs
            _recentLogs.Add(logMessage);
            if (_recentLogs.Count > 1000)
                _recentLogs.RemoveAt(0);
            
            // Send critical logs to external service
            if (logMessage.Contains("[Fehler]") || logMessage.Contains("[Immer]"))
            {
                SendToMonitoring(logMessage);
            }
        };
    }
    
    public IEnumerable<string> GetRecentLogs(int count = 100)
    {
        return _recentLogs.TakeLast(count);
    }
}
```

## Best Practices

1. **Use appropriate log levels** - Don't spam production with Diagnose logs
2. **Include context** - Helps filter and categorize logs
3. **Log exceptions properly** - Use `L.Fehler(ex, message)` overload
4. **Structured messages** - Include relevant IDs and values
5. **Don't log sensitive data** - Never log passwords or tokens
6. **Configure per environment** - More verbose in development

---

For complete API documentation, see the [API Reference](/docs/api/csharp).

---
sidebar_position: 1
---

# C# Libraries Overview

The IDAS C# Client Libraries provide a comprehensive set of tools for building .NET applications that integrate with the Gandalan IDAS platform. These libraries are distributed as NuGet packages and support both modern .NET and legacy .NET Framework applications.

## Available Packages

### 1. Gandalan.IDAS.WebApi.Client

The core library for communicating with IDAS REST APIs.

**Features:**
- REST client with automatic serialization
- Business routine pattern for API operations
- Authentication and token management
- Rate limiting support
- Compression support

```bash
dotnet add package Gandalan.IDAS.WebApi.Client
```

### 2. Gandalan.IDAS.WebApi.Client.Wpf

WPF-specific components and services for desktop applications.

**Features:**
- WPF services and controls
- MVVM support utilities
- Desktop-specific authentication flows

```bash
dotnet add package Gandalan.IDAS.WebApi.Client.Wpf
```

### 3. Gandalan.IDAS.Contracts

Contracts, base classes, and interfaces used across the IDAS ecosystem.

**Features:**
- `BelegBase` - Base class for business documents
- Repository pattern interfaces
- Command pattern contracts
- Change tracking attributes
- DTO contracts

```bash
dotnet add package Gandalan.IDAS.Contracts
```

### 4. Gandalan.IDAS.Crypto

Cryptographic utilities for encryption, hashing, and encoding.

**Features:**
- AES encryption/decryption
- BCrypt password hashing
- SHA1 hashing
- Hex encoding utilities

```bash
dotnet add package Gandalan.IDAS.Crypto
```

### 5. Gandalan.IDAS.Logging

Logging infrastructure with contextual logging support.

**Features:**
- `ILogger` interface
- `L` static class for easy logging
- Multiple log levels
- Context categorization
- File and console output

```bash
dotnet add package Gandalan.IDAS.Logging
```

## Target Frameworks

All packages target the following frameworks:

| Framework | Version | Status |
|-----------|---------|--------|
| .NET | 8.0 | ✅ Primary target |
| .NET Framework | 4.8 | ✅ Legacy support |

## Installation

### Using .NET CLI

```bash
# Install all packages
dotnet add package Gandalan.IDAS.WebApi.Client
dotnet add package Gandalan.IDAS.WebApi.Client.Wpf
dotnet add package Gandalan.IDAS.Contracts
dotnet add package Gandalan.IDAS.Crypto
dotnet add package Gandalan.IDAS.Logging
```

### Using Package Manager Console

```powershell
# Install all packages
Install-Package Gandalan.IDAS.WebApi.Client
Install-Package Gandalan.IDAS.WebApi.Client.Wpf
Install-Package Gandalan.IDAS.Contracts
Install-Package Gandalan.IDAS.Crypto
Install-Package Gandalan.IDAS.Logging
```

### Using PackageReference (csproj)

```xml
<ItemGroup>
  <PackageReference Include="Gandalan.IDAS.WebApi.Client" Version="1.0.0" />
  <PackageReference Include="Gandalan.IDAS.WebApi.Client.Wpf" Version="1.0.0" />
  <PackageReference Include="Gandalan.IDAS.Contracts" Version="1.0.0" />
  <PackageReference Include="Gandalan.IDAS.Crypto" Version="1.0.0" />
  <PackageReference Include="Gandalan.IDAS.Logging" Version="1.0.0" />
</ItemGroup>
```

## Package Dependencies

```
Gandalan.IDAS.WebApi.Client
├── Gandalan.IDAS.Contracts
├── Gandalan.IDAS.Logging
└── Newtonsoft.Json

Gandalan.IDAS.WebApi.Client.Wpf
└── Gandalan.IDAS.WebApi.Client

Gandalan.IDAS.Crypto
└── BCrypt.Net

Gandalan.IDAS.Logging
└── (no dependencies)

Gandalan.IDAS.Contracts
└── (no dependencies)
```

## Next Steps

- [Getting Started with C#](./getting-started) - Learn how to set up your first project
- [WebApi.Client Guide](./webapi-client) - Deep dive into the REST client
- [API Reference](/api/csharp) - Browse the complete API documentation

---

## Quick Example

```csharp
using Gandalan.IDAS.WebApi.Client;
using Gandalan.IDAS.WebApi.Client.Settings;

// Configure settings
var settings = new WebApiSettings
{
    Url = "https://idas.gandalan.de",
    UserName = "your-username",
    Passwort = "your-password",
    AppToken = Guid.Parse("your-app-token")
};

// Create business routine
var vorgangRoutinen = new VorgangWebRoutinen(settings);

// Load data
var vorgaenge = await vorgangRoutinen.LadeVorgangsListeAsync(2025);
```

---
sidebar_position: 1
slug: /
---

# Welcome to IDAS Client Libraries

The **IDAS Client Libraries** provide comprehensive client-side implementations for integrating with the Gandalan IDAS (Integriertes Daten- und Auftrags-System) platform. These libraries enable developers to build applications that interact with IDAS services for business document management, production planning, and more.

## What are the IDAS Client Libraries?

The IDAS Client Libraries are a collection of .NET and JavaScript/TypeScript libraries designed to simplify integration with the IDAS ecosystem. They provide:

- **Type-safe API clients** for RESTful communication
- **Authentication and authorization** helpers
- **DTOs (Data Transfer Objects)** for seamless data exchange
- **Business logic routines** for common operations
- **Utility libraries** for cryptography, logging, and more

## C# Libraries Overview

The C# libraries consist of **5 NuGet packages** targeting modern .NET platforms:

| Package | Description |
|---------|-------------|
| **Gandalan.IDAS.WebApi.Client** | Core REST client and business routines for IDAS API communication |
| **Gandalan.IDAS.WebApi.Client.Wpf** | WPF-specific components and services |
| **Gandalan.IDAS.Contracts** | Contracts, DTOs, and base classes for IDAS entities |
| **Gandalan.IDAS.Crypto** | Cryptographic utilities (AES, BCrypt, SHA1) |
| **Gandalan.IDAS.Logging** | Logging infrastructure and helpers |

### Target Frameworks

- **.NET 8.0** (primary target)
- **.NET Framework 4.8** (legacy support)

## WebLibs Overview

**@gandalan/weblibs** is a JavaScript/TypeScript library for building web applications that integrate with IDAS:

- **Fluent API** for intuitive HTTP requests
- **Authentication management** with JWT and refresh tokens
- **REST client** with automatic retry and error handling
- **Svelte components** and UI utilities

## Quick Links

<div className="row">
  <div className="col col--6 margin-bottom--lg">
    <div className="card">
      <div className="card__header">
        <h3>🚀 Getting Started</h3>
      </div>
      <div className="card__body">
        <p>Learn how to install and configure the libraries for your project.</p>
      </div>
      <div className="card__footer">
        <a className="button button--primary button--block" href="/docs/guides/csharp/getting-started">C# Guide</a>
        <a className="button button--secondary button--block margin-top--sm" href="/docs/guides/weblibs/getting-started">WebLibs Guide</a>
      </div>
    </div>
  </div>
  <div className="col col--6 margin-bottom--lg">
    <div className="card">
      <div className="card__header">
        <h3>📚 API Reference</h3>
      </div>
      <div className="card__body">
        <p>Explore the complete API documentation for all libraries.</p>
      </div>
      <div className="card__footer">
        <a className="button button--primary button--block" href="/docs/api/intro">View API Docs</a>
      </div>
    </div>
  </div>
</div>

## Architecture Overview

```
┌─────────────────────────────────────────────────────────────┐
│                    Your Application                         │
└───────────────────────┬─────────────────────────────────────┘
                        │
        ┌───────────────┼───────────────┐
        │                               │
┌───────▼────────┐          ┌───────────▼────────┐
│  C# Libraries  │          │    WebLibs         │
│                │          │  (JavaScript/TS)   │
│ • WebApi.Client│          │                    │
│ • Contracts    │          │ • Fluent API       │
│ • Crypto       │          │ • Auth Manager     │
│ • Logging      │          │ • REST Client      │
└───────┬────────┘          └───────────┬────────┘
        │                               │
        └───────────────┬───────────────┘
                        │
        ┌───────────────▼───────────────┐
        │      IDAS REST API            │
        │  (JSON over HTTPS)            │
        └───────────────────────────────┘
```

## Getting Help

- **GitHub Issues**: [Report bugs or request features](https://github.com/gandalan/idas-client-libs/issues)
- **GitHub Discussions**: [Ask questions and share ideas](https://github.com/gandalan/idas-client-libs/discussions)
- **Documentation**: Browse the guides and API reference in the navigation

---

*Copyright © 2025 Gandalan GmbH. All rights reserved.*

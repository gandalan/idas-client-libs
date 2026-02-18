---
sidebar_position: 1
sidebar_label: Overview
---

# C# API Reference

This section contains the auto-generated API reference documentation for all C# libraries in the IDAS Client Libraries project.

## Libraries

- **Gandalan.IDAS.WebApi.Client** - Core Web API client with REST routines, DTOs, and business routines
- **Gandalan.IDAS.Crypto** - Encryption and hashing utilities (AES, BCrypt, SHA1)
- **Gandalan.IDAS.Logging** - Logging infrastructure and interfaces
- **Gandalan.IDAS.WebApi.Client.Wpf** - WPF-specific controls and dialogs
- **Gandalan.IDAS.Contracts** - Base contracts, interfaces, and change tracking

## Building the Documentation

The C# API documentation is automatically generated from:
1. XML documentation comments in the source code
2. DocFX metadata extraction
3. Conversion to Docusaurus-compatible Markdown

To regenerate the C# API documentation, run:

```powershell
cd docs
.\scripts\generate-csharp-docs.ps1
```

:::info Auto-Generated
This documentation is automatically generated from the C# XML documentation files. Any changes to the source code documentation comments will be reflected here when the documentation is rebuilt.
:::

---
sidebar_position: 1
---

# WebLibs Overview

**@gandalan/weblibs** is a comprehensive JavaScript/TypeScript library for building web applications that integrate with the Gandalan IDAS platform.

## What is @gandalan/weblibs?

WebLibs provides a modern, fluent API for interacting with IDAS services from browser-based applications. It abstracts away the complexity of authentication, HTTP communication, and data handling, allowing you to focus on building your application.

## Package Installation

### Using npm

```bash
npm install @gandalan/weblibs
```

### Using yarn

```bash
yarn add @gandalan/weblibs
```

### Using pnpm

```bash
pnpm add @gandalan/weblibs
```

## Architecture Overview

WebLibs is organized into several modules:

```
@gandalan/weblibs/
├── api/
│   ├── fluentApi.js          # Fluent API for HTTP requests
│   ├── fluentAuthManager.js  # Authentication management
│   ├── fluentRestClient.js   # REST client implementation
│   ├── fluentEnvUtils.js     # Environment configuration
│   ├── fluentAuthUtils.js    # Authentication utilities
│   ├── IDAS.js               # Legacy IDAS factory
│   └── RESTClient.js         # Legacy REST client
├── ui/
│   ├── components/           # Svelte components
│   ├── stores/               # Svelte stores
│   └── utils/                # UI utilities
└── index.js                  # Main exports
```

## Key Features

### 1. Fluent API

Build API requests with an intuitive, chainable interface:

```javascript
import { createApi, createAuthManager } from "@gandalan/weblibs";

const authManager = createAuthManager()
  .useAppToken("your-app-token")
  .useBaseUrl("https://auth.gandalan.de");

const api = createApi()
  .useBaseUrl("https://api.gandalan.de")
  .useAuthManager(authManager)
  .useServiceName("MyApp");

// Make requests
const data = await api.get("/Vorgang");
const result = await api.post("/Vorgang", { name: "New" });
```

### 2. Authentication Management

Built-in JWT and refresh token handling:

```javascript
import { createAuthManager } from "@gandalan/weblibs";

const auth = createAuthManager()
  .useAppToken("your-app-token")
  .useBaseUrl("https://auth.gandalan.de");

// Login
await auth.login("user@example.com", "password");

// Check permissions
if (auth.hasRight("BelegeBearbeiten")) {
  // Allow editing
}
```

### 3. REST Client

Low-level HTTP client with automatic retries and error handling:

```javascript
import { restClient } from "@gandalan/weblibs";

const client = restClient()
  .useBaseUrl("https://api.gandalan.de")
  .useToken("jwt-token")
  .useUserAgent("MyApp/1.0");

const data = await client.get("/Endpoint");
```

### 4. Environment Configuration

Fetch environment-specific configuration:

```javascript
import { fetchEnvConfig } from "@gandalan/weblibs";

const config = await fetchEnvConfig("Production");
console.log(config.apiUrl);  // "https://api.gandalan.de"
```

### 5. UI Components (Svelte)

Pre-built Svelte components for common IDAS operations:

```svelte
<script>
  import { AuthStore } from "@gandalan/weblibs";
</script>

<AuthStore let:user>
  <div>Welcome, {user.name}!</div>
</AuthStore>
```

## Dependencies

WebLibs has minimal dependencies:

- **axios** - HTTP client
- **jwt-decode** - JWT token decoding
- **validator** - Input validation
- **@mdi/js** - Material Design Icons

## Browser Support

WebLibs supports modern browsers:

- Chrome 80+
- Firefox 75+
- Safari 13.1+
- Edge 80+

## Module Types

WebLibs is distributed as ES modules:

```javascript
// ES Modules (recommended)
import { createApi } from "@gandalan/weblibs";

// Specific imports
import { createAuthManager } from "@gandalan/weblibs/api/fluentAuthManager";
```

## Quick Links

<div className="row">
  <div className="col col--4 margin-bottom--lg">
    <div className="card">
      <div className="card__header">
        <h3>Getting Started</h3>
      </div>
      <div className="card__body">
        <p>Installation and basic setup</p>
      </div>
      <div className="card__footer">
        <a className="button button--primary button--block" href="./getting-started">Read Guide</a>
      </div>
    </div>
  </div>
  <div className="col col--4 margin-bottom--lg">
    <div className="card">
      <div className="card__header">
        <h3>Fluent API</h3>
      </div>
      <div className="card__body">
        <p>HTTP requests made easy</p>
      </div>
      <div className="card__footer">
        <a className="button button--primary button--block" href="./fluent-api">Read Guide</a>
      </div>
    </div>
  </div>
  <div className="col col--4 margin-bottom--lg">
    <div className="card">
      <div className="card__header">
        <h3>Authentication</h3>
      </div>
      <div className="card__body">
        <p>User login and tokens</p>
      </div>
      <div className="card__footer">
        <a className="button button--primary button--block" href="./authentication">Read Guide</a>
      </div>
    </div>
  </div>
</div>

## Example: Complete Application Setup

```javascript
// app.js
import { createApi, createAuthManager, fetchEnvConfig } from "@gandalan/weblibs";

async function initApp() {
  // Load environment configuration
  const envConfig = await fetchEnvConfig("Production");
  
  // Initialize authentication
  const authManager = createAuthManager()
    .useAppToken(envConfig.appToken)
    .useBaseUrl(envConfig.authUrl);
  
  // Initialize API
  const api = createApi()
    .useBaseUrl(envConfig.apiUrl)
    .useAuthManager(authManager)
    .useServiceName("MyWebApp");
  
  // Check existing session
  try {
    await authManager.init();
    console.log("User is authenticated");
  } catch {
    console.log("User needs to login");
  }
  
  // Make API calls
  const vorgaenge = await api.get("/Vorgang");
  console.log(`Loaded ${vorgaenge.length} Vorgänge`);
  
  return { api, authManager };
}

export const { api, authManager } = await initApp();
```

## Next Steps

- [Getting Started with WebLibs](./getting-started) - Installation and setup
- [Fluent API Guide](./fluent-api) - Learn the fluent API pattern
- [Authentication Guide](./authentication) - User authentication and permissions
- [API Reference](/api/weblibs) - Complete API documentation

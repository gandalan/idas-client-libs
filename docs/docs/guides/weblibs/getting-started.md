---
sidebar_position: 2
---

# Getting Started with WebLibs

This guide will help you get up and running with @gandalan/weblibs in your web application.

## Prerequisites

Before you begin, ensure you have the following:

### Required

- **Node.js** 16.x or higher
  - Download from [nodejs.org](https://nodejs.org/)
  - Verify with: `node --version`

- **npm** 7.x or higher (included with Node.js)
  - Verify with: `npm --version`

### Optional but Recommended

- **TypeScript** 4.5+ for type safety
- A modern JavaScript framework (Svelte, React, Vue, etc.)
- Bundler (Vite, Webpack, Rollup, etc.)

## Installation

### Step 1: Create a New Project (if needed)

```bash
# Using Vite with Svelte (recommended)
npm create vite@latest my-idas-app -- --template svelte
cd my-idas-app

# Or with TypeScript
npm create vite@latest my-idas-app -- --template svelte-ts
cd my-idas-app
```

### Step 2: Install WebLibs

```bash
npm install @gandalan/weblibs
```

### Step 3: Install Peer Dependencies

```bash
npm install axios jwt-decode validator
```

## Basic Setup Example

### 1. Environment Configuration

Create an environment configuration file:

```javascript
// config.js
export const environments = {
  development: {
    appToken: "your-dev-app-token",
    apiUrl: "https://dev-api.gandalan.de",
    authUrl: "https://dev-auth.gandalan.de"
  },
  production: {
    appToken: "your-prod-app-token",
    apiUrl: "https://api.gandalan.de",
    authUrl: "https://auth.gandalan.de"
  }
};

export function getEnvConfig(env = "development") {
  return environments[env] || environments.development;
}
```

### 2. Initialize Authentication

```javascript
// auth.js
import { createAuthManager } from "@gandalan/weblibs";
import { getEnvConfig } from "./config.js";

const config = getEnvConfig(import.meta.env.MODE);

export const authManager = createAuthManager()
  .useAppToken(config.appToken)
  .useBaseUrl(config.authUrl);

// Initialize from stored tokens
export async function initAuth() {
  try {
    await authManager.init();
    return { authenticated: true, user: authManager.userInfo };
  } catch (error) {
    return { authenticated: false, error };
  }
}

// Login function
export async function login(email, password) {
  try {
    await authManager.login(email, password);
    return { success: true, user: authManager.userInfo };
  } catch (error) {
    return { success: false, error: error.message };
  }
}

// Logout function
export function logout() {
  localStorage.removeItem("idas-refresh-token");
  authManager.token = "";
  authManager.refreshToken = "";
  authManager.userInfo = {};
}
```

### 3. Create API Client

```javascript
// api.js
import { createApi } from "@gandalan/weblibs";
import { authManager } from "./auth.js";
import { getEnvConfig } from "./config.js";

const config = getEnvConfig(import.meta.env.MODE);

export const api = createApi()
  .useBaseUrl(config.apiUrl)
  .useAuthManager(authManager)
  .useServiceName("MyWebApp");

// Helper functions
export async function loadVorgaenge(year = new Date().getFullYear()) {
  return await api.get(`/Vorgang/?jahr=${year}`);
}

export async function loadVorgang(guid) {
  return await api.get(`/Vorgang/${guid}?includeKunde=true`);
}

export async function saveVorgang(vorgang) {
  return await api.put("/Vorgang", vorgang);
}
```

### 4. Use in Your Application

```svelte
<!-- App.svelte -->
<script>
  import { onMount } from "svelte";
  import { initAuth, login, logout, authManager } from "./auth.js";
  import { loadVorgaenge } from "./api.js";
  
  let user = null;
  let loading = true;
  let vorgaenge = [];
  
  onMount(async () => {
    const auth = await initAuth();
    if (auth.authenticated) {
      user = auth.user;
      vorgaenge = await loadVorgaenge();
    }
    loading = false;
  });
  
  async function handleLogin(event) {
    const formData = new FormData(event.target);
    const result = await login(
      formData.get("email"),
      formData.get("password")
    );
    
    if (result.success) {
      user = result.user;
      vorgaenge = await loadVorgaenge();
    } else {
      alert("Login failed: " + result.error);
    }
  }
</script>

{#if loading}
  <p>Loading...</p>
{:else if user}
  <div>
    <h1>Welcome, {user.name}!</h1>
    <button on:click={logout}>Logout</button>
    
    <h2>Vorgänge</h2>
    <ul>
      {#each vorgaenge as vorgang}
        <li>{vorgang.vorgangsNummer} - {vorgang.kundeName}</li>
      {/each}
    </ul>
  </div>
{:else}
  <form on:submit|preventDefault={handleLogin}>
    <h1>Login</h1>
    <input type="email" name="email" placeholder="Email" required />
    <input type="password" name="password" placeholder="Password" required />
    <button type="submit">Login</button>
  </form>
{/if}
```

## Environment Configuration

### Using Environment Variables

With Vite, you can use environment variables:

```bash
# .env.development
VITE_IDAS_APP_TOKEN=your-dev-token
VITE_IDAS_API_URL=https://dev-api.gandalan.de
VITE_IDAS_AUTH_URL=https://dev-auth.gandalan.de
```

```javascript
// config.js
export const config = {
  appToken: import.meta.env.VITE_IDAS_APP_TOKEN,
  apiUrl: import.meta.env.VITE_IDAS_API_URL,
  authUrl: import.meta.env.VITE_IDAS_AUTH_URL
};
```

### Fetching Environment Config

Alternatively, fetch configuration from a server:

```javascript
import { fetchEnvConfig } from "@gandalan/weblibs";

const envConfig = await fetchEnvConfig("Production");
// Returns: { appToken, apiUrl, authUrl, ... }
```

## Authentication Initialization

### Automatic Token Refresh

WebLibs handles token refresh automatically:

```javascript
import { authManager } from "./auth.js";

// On app startup
try {
  await authManager.init();
  // User is authenticated, tokens are valid or refreshed
} catch {
  // User needs to login
  redirectToLogin();
}
```

### Manual Login

```javascript
async function authenticate(email, password) {
  try {
    await authManager.login(email, password);
    
    // Store tokens (handled automatically by authManager)
    console.log("Authenticated:", authManager.userInfo);
    
    return true;
  } catch (error) {
    console.error("Authentication failed:", error);
    return false;
  }
}
```

## Next Steps

Now that you have the basics set up:

- [Fluent API Guide](./fluent-api) - Learn how to make API requests
- [Authentication Guide](./authentication) - Deep dive into authentication
- [API Reference](/docs/api/weblibs) - Complete API documentation

## Troubleshooting

### Common Issues

**CORS Errors**
Ensure your app's domain is allowlisted in the IDAS backend.

**Token Expired**
The library automatically refreshes tokens. If refresh fails, the user will be redirected to login.

**Module Not Found**
Ensure you're using ES modules and have the correct import paths.

### Getting Help

- Check the [API Reference](/docs/api/weblibs)
- Review the [source code on GitHub](https://github.com/gandalan/idas-client-libs)
- Open an [issue on GitHub](https://github.com/gandalan/idas-client-libs/issues)

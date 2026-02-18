---
sidebar_position: 4
---

# Authentication Guide

The **Authentication Manager** in @gandalan/weblibs handles user authentication, token management, and permission checking for IDAS web applications.

## Overview

The authentication system provides:

- **createAuthManager()** - Factory for creating auth manager instances
- **JWT Token Management** - Automatic handling of access and refresh tokens
- **Login Flow** - Username/password authentication
- **Token Refresh** - Automatic token renewal
- **Permission Checking** - Rights and roles verification

## Creating an Auth Manager

### Basic Setup

```javascript
import { createAuthManager } from "@gandalan/weblibs";

const authManager = createAuthManager()
  .useAppToken("your-app-token")
  .useBaseUrl("https://auth.gandalan.de");
```

### Configuration Methods

| Method | Description | Returns |
|--------|-------------|---------|
| `useAppToken(token)` | Set the application token (UUID) | `FluentAuthManager` |
| `useBaseUrl(url)` | Set the authentication URL | `FluentAuthManager` |
| `useToken(jwtToken)` | Set JWT token (for service tokens) | `FluentAuthManager` |
| `useRefreshToken(token)` | Set refresh token | `FluentAuthManager` |

## Login Flow

### User Login

```javascript
import { createAuthManager } from "@gandalan/weblibs";

const authManager = createAuthManager()
  .useAppToken("your-app-token")
  .useBaseUrl("https://auth.gandalan.de");

async function handleLogin(email, password) {
  try {
    await authManager.login(email, password);
    
    console.log("Login successful!");
    console.log("User:", authManager.userInfo);
    console.log("Token:", authManager.token);
    
    return true;
  } catch (error) {
    console.error("Login failed:", error.message);
    return false;
  }
}
```

### Login Form Example

```svelte
<!-- LoginForm.svelte -->
<script>
  import { createAuthManager } from "@gandalan/weblibs";
  
  const authManager = createAuthManager()
    .useAppToken(import.meta.env.VITE_IDAS_APP_TOKEN)
    .useBaseUrl(import.meta.env.VITE_IDAS_AUTH_URL);
  
  let email = "";
  let password = "";
  let loading = false;
  let error = null;
  
  async function submit() {
    loading = true;
    error = null;
    
    try {
      await authManager.login(email, password);
      // Redirect or update app state
      window.location.href = "/dashboard";
    } catch (err) {
      error = "Invalid email or password";
    } finally {
      loading = false;
    }
  }
</script>

<form on:submit|preventDefault={submit}>
  <h2>Login</h2>
  
  {#if error}
    <div class="error">{error}</div>
  {/if}
  
  <input
    type="email"
    bind:value={email}
    placeholder="Email"
    required
  />
  
  <input
    type="password"
    bind:value={password}
    placeholder="Password"
    required
  />
  
  <button type="submit" disabled={loading}>
    {loading ? "Logging in..." : "Login"}
  </button>
</form>
```

## Token Management

### Initialization

The `init()` method checks for existing tokens and validates them:

```javascript
import { createAuthManager } from "@gandalan/weblibs";

const authManager = createAuthManager()
  .useAppToken("your-app-token")
  .useBaseUrl("https://auth.gandalan.de");

async function initializeAuth() {
  try {
    // This will:
    // 1. Check localStorage for refresh token
    // 2. Check URL for refresh token (from redirect)
    // 3. Validate existing JWT token
    // 4. Refresh if needed
    // 5. Redirect to login if no valid tokens
    
    await authManager.init();
    
    console.log("User is authenticated");
    console.log("User info:", authManager.userInfo);
    
    return { authenticated: true, user: authManager.userInfo };
  } catch (error) {
    console.log("User needs to login");
    return { authenticated: false };
  }
}
```

### Token Storage

Tokens are automatically stored in:

- **localStorage** - Refresh token persists across sessions
- **Memory** - JWT token (short-lived)

```javascript
// After successful login
console.log(authManager.token);        // JWT access token
console.log(authManager.refreshToken); // Refresh token
console.log(authManager.userInfo);     // Decoded user info from JWT
```

### Manual Token Management

For advanced scenarios (e.g., service tokens):

```javascript
// Set tokens manually
authManager
  .useToken("jwt-access-token")
  .useRefreshToken("refresh-token");

// Check if token is valid
const isValid = isTokenValid(authManager.token);

// Get refresh token from JWT
import { getRefreshToken } from "@gandalan/weblibs";
const refreshToken = getRefreshToken(authManager.token);
```

## Refresh Tokens

### Automatic Refresh

The auth manager automatically refreshes tokens when they expire:

```javascript
const authManager = createAuthManager()
  .useAppToken("app-token")
  .useBaseUrl("https://auth.gandalan.de");

// This will automatically refresh if needed
await authManager.ensureAuthenticated();
```

### Manual Refresh

```javascript
async function refreshAuth() {
  try {
    await authManager.authenticate();
    console.log("Token refreshed");
    console.log("New token:", authManager.token);
  } catch (error) {
    console.error("Refresh failed:", error);
    // User needs to login again
  }
}
```

### Refresh Token Flow

```javascript
import { createAuthManager } from "@gandalan/weblibs";

async function tryRefreshToken() {
  const authManager = createAuthManager()
    .useAppToken("app-token")
    .useBaseUrl("https://auth.gandalan.de")
    .useRefreshToken("stored-refresh-token");
  
  try {
    // Try to refresh the JWT token
    const newToken = await authManager.tryRefreshToken("stored-refresh-token");
    
    if (newToken) {
      console.log("Token refreshed successfully");
      authManager.updateUserSession(newToken);
    }
  } catch (error) {
    console.error("Token refresh failed");
  }
}
```

## Permission Checking

### Checking Rights

```javascript
// Check if user has a specific right
if (authManager.hasRight("BelegeBearbeiten")) {
  // Show edit button
}

// Check multiple rights
const canEdit = authManager.hasRight("BelegeBearbeiten");
const canDelete = authManager.hasRight("BelegeLoeschen");
const canArchive = authManager.hasRight("BelegeArchivieren");
```

### Checking Roles

```javascript
// Check if user has a specific role
if (authManager.hasRole("Admin")) {
  // Show admin features
}

// Check multiple roles
const isAdmin = authManager.hasRole("Admin");
const isManager = authManager.hasRole("Manager");
```

### Permission-Based UI

```svelte
<!-- VorgangDetail.svelte -->
<script>
  import { authManager } from "./auth.js";
  
  export let vorgang;
  
  $: canEdit = authManager.hasRight("BelegeBearbeiten");
  $: canDelete = authManager.hasRight("BelegeLoeschen");
  $: canArchive = authManager.hasRight("BelegeArchivieren");
</script>

<div class="vorgang-detail">
  <h1>Vorgang {vorgang.vorgangsNummer}</h1>
  
  <div class="actions">
    {#if canEdit}
      <button on:click={handleEdit}>Edit</button>
    {/if}
    
    {#if canArchive}
      <button on:click={handleArchive}>Archive</button>
    {/if}
    
    {#if canDelete}
      <button on:click={handleDelete} class="danger">Delete</button>
    {/if}
  </div>
  
  <!-- Vorgang details -->
</div>
```

## Complete Authentication Example

### auth.js - Authentication Module

```javascript
import { createAuthManager, getRefreshToken } from "@gandalan/weblibs";

// Configuration
const config = {
  appToken: import.meta.env.VITE_IDAS_APP_TOKEN,
  authUrl: import.meta.env.VITE_IDAS_AUTH_URL
};

// Create auth manager instance
export const authManager = createAuthManager()
  .useAppToken(config.appToken)
  .useBaseUrl(config.authUrl);

// Initialize authentication
export async function initAuth() {
  try {
    await authManager.init();
    return {
      authenticated: true,
      user: authManager.userInfo
    };
  } catch (error) {
    return {
      authenticated: false,
      error: error.message
    };
  }
}

// Login
export async function login(email, password) {
  try {
    await authManager.login(email, password);
    return {
      success: true,
      user: authManager.userInfo
    };
  } catch (error) {
    return {
      success: false,
      error: error.message
    };
  }
}

// Logout
export function logout() {
  localStorage.removeItem("idas-refresh-token");
  authManager.token = "";
  authManager.refreshToken = "";
  authManager.userInfo = {};
  window.location.href = "/login";
}

// Check permissions
export function hasRight(right) {
  return authManager.hasRight(right);
}

export function hasRole(role) {
  return authManager.hasRole(role);
}

// Get user info
export function getUserInfo() {
  return authManager.userInfo;
}

// Check if authenticated
export function isAuthenticated() {
  return !!authManager.token && authManager.userInfo?.id;
}
```

### App.svelte - Application Setup

```svelte
<script>
  import { onMount } from "svelte";
  import { initAuth, authManager } from "./auth.js";
  import Login from "./Login.svelte";
  import Dashboard from "./Dashboard.svelte";
  
  let authState = {
    loading: true,
    authenticated: false,
    user: null
  };
  
  onMount(async () => {
    const result = await initAuth();
    authState = {
      loading: false,
      authenticated: result.authenticated,
      user: result.user
    };
  });
  
  function handleLoginSuccess(event) {
    authState.authenticated = true;
    authState.user = event.detail.user;
  }
</script>

{#if authState.loading}
  <div class="loading">Loading...</div>
{:else if authState.authenticated}
  <Dashboard user={authState.user} />
{:else}
  <Login on:success={handleLoginSuccess} />
{/if}
```

## Error Handling

### Common Authentication Errors

```javascript
async function authenticate(email, password) {
  try {
    await authManager.login(email, password);
    return { success: true };
  } catch (error) {
    if (error.message.includes("401")) {
      return { 
        success: false, 
        error: "Invalid email or password" 
      };
    }
    if (error.message.includes("403")) {
      return { 
        success: false, 
        error: "Account is disabled" 
      };
    }
    return { 
      success: false, 
      error: "Authentication failed. Please try again." 
    };
  }
}
```

## Best Practices

1. **Always call init() on startup** - Handles token recovery
2. **Use ensureAuthenticated() before API calls** - Automatic refresh
3. **Check permissions before showing UI** - hasRight(), hasRole()
4. **Store app token securely** - Use environment variables
5. **Handle logout properly** - Clear tokens and redirect
6. **Use HTTPS** - Never transmit tokens over HTTP

---

For complete API documentation, see the [API Reference](/api/weblibs).

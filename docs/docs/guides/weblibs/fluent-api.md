---
sidebar_position: 3
---

# Fluent API Guide

The **Fluent API** in @gandalan/weblibs provides an intuitive, chainable interface for making HTTP requests to IDAS services.

## Overview

The Fluent API is built around the `createApi()` function, which returns an object with methods that can be chained together to configure and execute API requests.

## Creating an API Client

### Basic Setup

```javascript
import { createApi } from "@gandalan/weblibs";

const api = createApi();
```

### Configuration Methods

The `createApi()` function returns an object with the following configuration methods:

| Method | Description | Returns |
|--------|-------------|---------|
| `useBaseUrl(url)` | Set the base URL for API requests | `FluentApi` |
| `useAuthManager(authManager)` | Set the authentication manager | `FluentApi` |
| `useServiceName(name)` | Set the service name for user agent | `FluentApi` |

## Configuration Examples

### Basic Configuration

```javascript
import { createApi } from "@gandalan/weblibs";

const api = createApi()
  .useBaseUrl("https://api.gandalan.de")
  .useServiceName("MyApp");
```

### With Authentication

```javascript
import { createApi, createAuthManager } from "@gandalan/weblibs";

const authManager = createAuthManager()
  .useAppToken("your-app-token")
  .useBaseUrl("https://auth.gandalan.de");

const api = createApi()
  .useBaseUrl("https://api.gandalan.de")
  .useAuthManager(authManager)
  .useServiceName("MyWebApp");
```

## HTTP Methods

The Fluent API provides methods for all standard HTTP operations:

### GET Requests

```javascript
// Simple GET
const data = await api.get("/Vorgang");

// With authentication disabled
const publicData = await api.get("/Public/Info", false);

// GET with query parameters
const vorgaenge = await api.get("/Vorgang?jahr=2025&status=Offen");
```

### POST Requests

```javascript
// Create a new resource
const newVorgang = await api.post("/Vorgang", {
  kundeName: "ACME Corp",
  belegDatum: new Date().toISOString()
});

// Without authentication
const result = await api.post("/Public/Contact", data, false);
```

### PUT Requests

```javascript
// Update an existing resource
const updated = await api.put("/Vorgang", {
  vorgangGuid: "123-456",
  status: "Abgeschlossen"
});

// Update with specific ID
await api.put(`/Vorgang/${guid}/status`, { status: "Neu" });
```

### DELETE Requests

```javascript
// Delete a resource
await api.delete("/Vorgang/123-456");

// Delete with authentication disabled
await api.delete("/Temp/File", false);
```

## Chaining Examples

### Complete CRUD Example

```javascript
import { createApi, createAuthManager } from "@gandalan/weblibs";

class VorgangService {
  constructor() {
    this.authManager = createAuthManager()
      .useAppToken("app-token")
      .useBaseUrl("https://auth.gandalan.de");
    
    this.api = createApi()
      .useBaseUrl("https://api.gandalan.de")
      .useAuthManager(this.authManager)
      .useServiceName("VorgangService");
  }
  
  // Create
  async create(vorgangData) {
    return await this.api.post("/Vorgang", vorgangData);
  }
  
  // Read
  async getByGuid(guid) {
    return await this.api.get(`/Vorgang/${guid}?includeKunde=true`);
  }
  
  async getList(year) {
    return await this.api.get(`/Vorgang?jahr=${year}`);
  }
  
  // Update
  async update(vorgang) {
    return await this.api.put("/Vorgang", vorgang);
  }
  
  // Delete
  async delete(guid) {
    return await this.api.delete(`/Vorgang/${guid}`);
  }
  
  // Custom operations
  async changeStatus(guid, status) {
    return await this.api.post(
      `/Vorgang/${guid}/status`,
      { status }
    );
  }
  
  async archive(guid) {
    return await this.api.post(`/Archivierung?vguid=${guid}`, null);
  }
}

export const vorgangService = new VorgangService();
```

### Using with Svelte

```svelte
<!-- VorgangList.svelte -->
<script>
  import { onMount } from "svelte";
  import { api, authManager } from "./api.js";
  
  let vorgaenge = [];
  let loading = true;
  let error = null;
  
  onMount(async () => {
    try {
      // Ensure authenticated
      await authManager.ensureAuthenticated();
      
      // Load data
      vorgaenge = await api.get("/Vorgang?jahr=2025");
    } catch (err) {
      error = err.message;
    } finally {
      loading = false;
    }
  });
  
  async function handleArchive(vorgangGuid) {
    try {
      await api.post(`/Archivierung?vguid=${vorgangGuid}`, null);
      // Remove from list
      vorgaenge = vorgaenge.filter(v => v.vorgangGuid !== vorgangGuid);
    } catch (err) {
      alert("Archive failed: " + err.message);
    }
  }
</script>

{#if loading}
  <p>Loading...</p>
{:else if error}
  <p class="error">{error}</p>
{:else}
  <ul>
    {#each vorgaenge as vorgang}
      <li>
        {vorgang.vorgangsNummer} - {vorgang.kundeName}
        <button on:click={() => handleArchive(vorgang.vorgangGuid)}>
          Archive
        </button>
      </li>
    {/each}
  </ul>
{/if}
```

## Error Handling

The Fluent API throws errors for non-successful HTTP responses:

```javascript
try {
  const data = await api.get("/Vorgang/123");
} catch (error) {
  if (error.response) {
    // Server responded with error status
    console.error("Status:", error.response.status);
    console.error("Data:", error.response.data);
  } else if (error.request) {
    // Request made but no response
    console.error("No response received");
  } else {
    // Error in setting up request
    console.error("Error:", error.message);
  }
}
```

### Custom Error Handling

```javascript
class ApiService {
  constructor() {
    this.api = createApi()
      .useBaseUrl("https://api.gandalan.de")
      .useAuthManager(authManager);
  }
  
  async safeRequest(requestFn) {
    try {
      return { success: true, data: await requestFn() };
    } catch (error) {
      if (error.response?.status === 401) {
        return { success: false, error: "Unauthorized" };
      }
      if (error.response?.status === 404) {
        return { success: false, error: "Not found" };
      }
      return { success: false, error: error.message };
    }
  }
  
  async getVorgang(guid) {
    return this.safeRequest(() => this.api.get(`/Vorgang/${guid}`));
  }
}
```

## Authentication Handling

The Fluent API automatically handles authentication when an `authManager` is configured:

```javascript
const api = createApi()
  .useAuthManager(authManager);

// Before each request, the API will:
// 1. Check if token is valid
// 2. Refresh if needed
// 3. Add Authorization header
// 4. Make the request

const data = await api.get("/Vorgang"); // Auth handled automatically
```

### Skip Authentication

For public endpoints, you can skip authentication:

```javascript
// Skip auth for this request
const publicData = await api.get("/Public/Info", false);
```

## Advanced Usage

### Request Interception

You can extend the API client with custom behavior:

```javascript
import { createApi } from "@gandalan/weblibs";

function createCustomApi() {
  const api = createApi()
    .useBaseUrl("https://api.gandalan.de")
    .useAuthManager(authManager);
  
  // Wrap methods with logging
  const originalGet = api.get.bind(api);
  api.get = async function(url, auth = true) {
    console.log(`GET ${url}`);
    const start = performance.now();
    try {
      const result = await originalGet(url, auth);
      console.log(`GET ${url} completed in ${performance.now() - start}ms`);
      return result;
    } catch (error) {
      console.error(`GET ${url} failed:`, error);
      throw error;
    }
  };
  
  return api;
}
```

### Batch Requests

```javascript
async function loadMultipleResources() {
  const api = createApi()
    .useBaseUrl("https://api.gandalan.de")
    .useAuthManager(authManager);
  
  // Parallel requests
  const [vorgaenge, kontakte, artikel] = await Promise.all([
    api.get("/Vorgang"),
    api.get("/Kontakt"),
    api.get("/Artikel")
  ]);
  
  return { vorgaenge, kontakte, artikel };
}
```

## Best Practices

1. **Reuse API instances** - Create once, use many times
2. **Always handle errors** - Wrap calls in try-catch
3. **Use authentication manager** - Let it handle tokens
4. **Set meaningful service names** - Helps with debugging
5. **Use environment variables** - Don't hardcode URLs

---

For complete API documentation, see the [API Reference](/api/weblibs).

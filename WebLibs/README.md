# WebLibs for Gandalan JS/TS/Svelte projects

## Initialize Fluent IDAS API + local API
Example:
```js
import { idasApi, localApi } from '@gandalan/weblibs/api/fluentApi';
import { createIdasAuthManager } from '@gandalan/weblibs/api/fluentAuthManager';
import { getCachedRefreshToken, popRefreshTokenFromUrl } from '@gandalan/weblibs/api/envUtils';
import { fetchEnv } from '@gandalan/weblibs/api/envUtils';

async function initializeAuthAndApi() {
  const appToken = 'your-app-token';
  const env = await fetchEnv('dev'); // Replace 'dev' with your desired environment
  const token = null; // JWT-Token, if available;
  const refreshToken = popRefreshTokenFromUrl() || getCachedRefreshToken(); // Refresh Token if available

  // Create + init IDAS authentication manager
  globalThis.authManager = await createIdasAuthManager(appToken, env, token, refreshToken).init();
  if (!globalThis.authManager) {
    return; // init() has redirected to login.
  }

  // Create IDAS API instance
  globalThis.idas = idasApi(env, authManager);

  // Create local API instance
  globalThis.api = localApi(authManager);
}
```

```js
// Example IDAS API usage
const responseIdas = await globalThis.idas.get('mandanten');
console.log(responseIdas[0].Name);

// Example local API usage
const responseApi = await globalThis.api.get('/some-endpoint');
console.log(responseApi);
```

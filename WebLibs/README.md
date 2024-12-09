# WebLibs for Gandalan JS/TS/Svelte projects

## Initialize Fluent IDAS API + local API
Example:
```js
import { fluentApi } from '@gandalan/weblibs/api/fluentApi';
import { fluentIdasAuthManager } from '@gandalan/weblibs/api/fluentAuthManager';
import { getCachedRefreshToken, popRefreshTokenFromUrl } from '@gandalan/weblibs/api/fluentAuthUtils';
import { fetchEnvConfig } from '@gandalan/weblibs/api/fluentEnvUtils';

async function initializeAuthAndApi() {
    const appToken = 'your-app-token';
    const envConfig = await fetchEnvConfig('dev'); // Replace 'dev' with your desired environment
    const refreshToken = popRefreshTokenFromUrl() || getCachedRefreshToken(); // refresh token, if available

    // Create + init IDAS authentication manager
    const authManager = await fluentIdasAuthManager(appToken, envConfig.idas, refreshToken).init();
    if (!authManager) {
        return; // init() has redirected to login.
    }

    // Create IDAS API instance
    globalThis.idas = fluentApi(envConfig.idas, authManager);
    // Create local API instance
    globalThis.api = fluentApi("/api/", authManager);
}
```

## Usage samples

```js
// Example IDAS API usage
const responseIdas = await globalThis.idas.get('mandanten');
console.log(responseIdas[0].Name);

// Example local API usage
const responseApi = await globalThis.api.get('some-endpoint');
console.log(responseApi);
```

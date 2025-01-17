# WebLibs for Gandalan JS/TS projects

## Initialize Fluent IDAS API + local API

Example:

```js
import { fetchEnvConfig, fluentApi, fluentIdasAuthManager } from '@gandalan/weblibs';

async function initializeAuthAndApi() {
    const appToken = 'your-app-token';
    const envConfig = await fetchEnvConfig('dev'); // Replace 'dev' with your desired environment

    const authManager = await fluentIdasAuthManager(appToken, envConfig.idas).init();
    if (!authManager) {
        return; // init() has redirected to login.
    }

    globalThis.idas = fluentApi(envConfig.idas, authManager);   // IDAS-API instance
    globalThis.api = fluentApi("/api/", authManager);           // Local API instance
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

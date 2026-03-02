# WebLibs for Gandalan JS/TS projects

## Deutsch

### Zweck
`@gandalan/weblibs` stellt Hilfsfunktionen für die Authentifizierung und API-Kommunikation mit IDAS sowie lokale API-Aufrufe bereit.

### Referenz
- IDAS API (Swagger): https://api.dev.idas-cloudservices.net/swagger/

### Voraussetzungen
- Browser-Umgebung (es werden `window`, `localStorage`, URL-Redirects und `fetch` verwendet)
- Gültiger App-Token als UUID (wird auf Anfrage von Gandalan ausgegeben)
- Kontakt für Zugangsdaten/App-Token: dev-support@gandalan.de
- IDAS/Auth-Base-URL vorzugsweise aus `fetchEnvConfig(...)` (z. B. `envConfig.idas`)
- Falls die URL manuell gesetzt wird: mit abschließendem Slash (z. B. `https://api.dev.idas-cloudservices.net/api/`)

### Installation
```bash
npm i @gandalan/weblibs
```

### Schnellstart (Fluent API + Auth)
```js
import { fetchEnvConfig, fluentApi, fluentIdasAuthManager } from '@gandalan/weblibs';

async function initializeAuthAndApi() {
    const serviceName = 'myService';
    const appToken = '00000000-0000-0000-0000-000000000000'; // UUID
    const envConfig = await fetchEnvConfig('dev'); // envConfig.idas kommt aus fetchEnvConfig(...)

    let authManager;
    try {
        authManager = await fluentIdasAuthManager(appToken, envConfig.idas).init();
    } catch {
        // init() kann auf Login umleiten und dabei eine Exception werfen.
        // In diesem Fall Seite verlassen / später erneut starten.
        return;
    }

    const idas = fluentApi(envConfig.idas, authManager, serviceName);
    const api = fluentApi('/api/', authManager, serviceName);

    const mandanten = await idas.get('mandanten');
    console.log(mandanten[0]?.Name);

    const localResult = await api.get('some-endpoint');
    console.log(localResult);
}
```

### Exportierte APIs (Kurzüberblick)
- `fetchEnvConfig(env)` lädt Endpunktkonfiguration (z. B. `dev`, `staging`, `produktiv`)
- `fluentIdasAuthManager(appToken, authBaseUrl)` erzeugt Auth-Manager
- `fluentApi(baseUrl, authManager, serviceName)` erzeugt API-Client mit `get/put/post/delete`
- `createAuthManager()`, `createApi()`, `restClient()` für manuelle Konfiguration
- Legacy zusätzlich vorhanden: `initIDAS`, `IDASFactory`, `RESTClient`

### Wichtige Hinweise
- `init()` gibt nicht immer nur `null` zurück, sondern kann beim Redirect eine Exception auslösen.
- Refresh-Token wird aus URL-Parameter `t` gelesen und in `localStorage` (`idas-refresh-token`) persistiert.
- Ohne gültigen Auth-Status werden Requests ggf. intern per `ensureAuthenticated()` nachgezogen.

---

## English

### Purpose
`@gandalan/weblibs` provides helpers for authentication and API communication with IDAS as well as local API calls.

### Reference
- IDAS API (Swagger): https://api.dev.idas-cloudservices.net/swagger/

### Requirements
- Browser environment (uses `window`, `localStorage`, URL redirects, and `fetch`)
- Valid app token in UUID format (issued by Gandalan on request)
- Contact for credentials/app token: dev-support@gandalan.de
- Prefer the IDAS/auth base URL from `fetchEnvConfig(...)` (for example `envConfig.idas`)
- If the URL is set manually, use a trailing slash (for example `https://api.dev.idas-cloudservices.net/api/`)

### Installation
```bash
npm i @gandalan/weblibs
```

### Quick start (Fluent API + auth)
```js
import { fetchEnvConfig, fluentApi, fluentIdasAuthManager } from '@gandalan/weblibs';

async function initializeAuthAndApi() {
    const serviceName = 'myService';
    const appToken = '00000000-0000-0000-0000-000000000000'; // UUID
    const envConfig = await fetchEnvConfig('dev'); // envConfig.idas is provided by fetchEnvConfig(...)

    let authManager;
    try {
        authManager = await fluentIdasAuthManager(appToken, envConfig.idas).init();
    } catch {
        // init() may redirect to login and throw while doing so.
        return;
    }

    const idas = fluentApi(envConfig.idas, authManager, serviceName);
    const api = fluentApi('/api/', authManager, serviceName);

    const mandanten = await idas.get('mandanten');
    console.log(mandanten[0]?.Name);

    const localResult = await api.get('some-endpoint');
    console.log(localResult);
}
```

### Exported APIs (short overview)
- `fetchEnvConfig(env)` loads endpoint configuration (for example `dev`, `staging`, `produktiv`)
- `fluentIdasAuthManager(appToken, authBaseUrl)` creates an auth manager
- `fluentApi(baseUrl, authManager, serviceName)` creates an API client with `get/put/post/delete`
- `createAuthManager()`, `createApi()`, `restClient()` for manual composition
- Legacy exports still available: `initIDAS`, `IDASFactory`, `RESTClient`

### Important notes
- `init()` does not only return `null`; it may throw during login redirect.
- Refresh token can be read from URL parameter `t` and is stored in `localStorage` (`idas-refresh-token`).
- Without valid auth state, requests may trigger `ensureAuthenticated()` internally.

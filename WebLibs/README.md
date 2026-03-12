# WebLibs for Gandalan JS/TS projects

## Deutsch

### Zweck
`@gandalan/weblibs` stellt Fluent-APIs fuer IDAS und lokale REST-Aufrufe sowie das passende Auth-Handling bereit.

- `fetchEnvConfig(...)` fuer Endpunktkonfiguration
- `fluentIdasAuthManager(...)` fuer Authentifizierung
- `idasFluentApi(...)` fuer IDAS-Business-APIs
- `fluentApi(...)` fuer eigene oder lokale REST-Endpunkte

### Referenz
- IDAS API (Swagger): https://api.dev.idas-cloudservices.net/swagger/
- JSDoc-Regeln und Typing-Konventionen: [JSDOC.md](./JSDOC.md)

### Voraussetzungen
- Browser-Umgebung
- Gueltiger App-Token im UUID-Format
- Zugangsdaten/App-Token ueber dev-support@gandalan.de
- IDAS-Basis-URL vorzugsweise aus `fetchEnvConfig(...)`

### Installation
```bash
npm i @gandalan/weblibs
```

### Schnellstart
```js
import {
    fetchEnvConfig,
    fluentApi,
    fluentIdasAuthManager,
    idasFluentApi
} from "@gandalan/weblibs";

async function initializeApis() {
    const appToken = "00000000-0000-0000-0000-000000000000";
    const serviceName = "myService";
    const envConfig = await fetchEnvConfig("dev");

    let authManager;

    try {
        authManager = await fluentIdasAuthManager(appToken, envConfig.idas).init();
    } catch {
        return null;
    }

    const idas = idasFluentApi(envConfig.idas, authManager, serviceName);
    const api = fluentApi("/api/", authManager, serviceName);

    return { idas, api, authManager };
}
```

### `init()`
- Liest Refresh-Token zuerst aus der URL, danach aus `localStorage`
- Versucht bei vorhandenem Refresh-Token ein JWT zu erneuern
- Kann bei fehlender gueltiger Session auf Login umleiten und dabei werfen

### Wichtige Exporte
- `fetchEnvConfig(env)`
- `fluentIdasAuthManager(appToken, authBaseUrl)`
- `fluentApi(baseUrl, authManager, serviceName)`
- `idasFluentApi(baseUrl, authManager, serviceName)`

### Wichtige Hinweise
- `idasFluentApi(...)` fuer IDAS-Business-Routinen verwenden
- `fluentApi(...)` fuer generische REST-Endpunkte verwenden
- `authManager.userInfo` und `idas.userInfo` enthalten dekodierte JWT-Claims
- Fuer JSDoc- und DTO-Typing-Regeln siehe [JSDOC.md](./JSDOC.md)

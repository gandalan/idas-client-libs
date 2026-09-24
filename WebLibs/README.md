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

### NeherApp3-Hosttypen
`api/neherApp3Types.js` ist die Master-Referenz fuer die Vertraege der
NeherApp3-Rahmen-App: `NeherApp3` (Host-API), `NeherApp3Module` (Modul-Einstieg),
`NeherApp3Messages` (In-Realm-Nachrichtenbus), `NeherApp3I18n`
(Lokalisierung: `localize` als Funktion *und* Svelte-Action, Modul-Kataloge,
sprachrichtige Sortierung) und `NeherApp3Theme` (Hell-/Dunkel-Modus; Module im
Shadow DOM liefern beide Themes mit, das `data-theme` setzt die Rahmen-App). Die Datei enthaelt nur Typen und wird von Hand
gepflegt; die Leitfaeden liegen im NeherApp3-Repository
(`docs/MODULE.md`, `docs/MESSAGING.md`, `docs/I18N.md`).

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

### Token-Erneuerung und Auth-Ereignisse
- Das JWT wird vor jedem Request erneuert, wenn es weniger als 30 s gilt, und zusaetzlich proaktiv (nur bei sichtbarem Dokument; war es verborgen, beim naechsten `visibilitychange`)
- Der proaktive Zeitpunkt ergibt sich aus der Token-Laufzeit (`exp - iat`) ab Empfang, nicht aus der Client-Uhr: `max(Laufzeit - 60 s, Laufzeit / 2, 30 s)`; zwischen zwei proaktiven Refreshes liegen mindestens 30 s (auch bei falsch gehender Uhr oder sehr kurzlebigen JWTs keine Refresh-Schleife)
- Der gesamte Sitzungszustand (Tokens, `userInfo`, Timer, Listener, Ablauf-Flag) liegt in einer Closure; `token`, `refreshToken` und `userInfo` sind Accessoren darauf. Ein tiefer Proxy auf den Auth-Manager (z. B. Svelte 5 `$state`) teilt sich deshalb Sitzung, Timer und Ereignisse mit dem Original
- Refreshes laufen tab-uebergreifend serialisiert (`navigator.locks`, Name `idas-refresh`); vor dem Refresh wird `localStorage["idas-refresh-token"]` neu gelesen, damit ein von einem anderen Tab rotiertes Token uebernommen wird
- Gehoert das mit einem uebernommenen Token erneuerte JWT zu einem anderen Benutzer (`benutzerGuid`/`id`) oder Mandanten (`mandantGuid`), wird es nicht uebernommen: die Sitzung endet mit `reason: "identity-changed"` (neu laden bzw. neu anmelden)
- Lehnt der Server den Refresh ab (jeder 4xx ausser 408/429), wird genau einmal mit einem inzwischen geaenderten Token aus `localStorage` erneut versucht; danach gilt die Sitzung als abgelaufen: Tokens werden geleert, das abgelehnte Token wird aus `localStorage` entfernt, bis zum naechsten Login/Refresh gehen keine Refresh-Requests mehr raus
- Netzwerkfehler, Timeouts, 408/429 und 5xx behalten das Refresh-Token; `init()` wirft sie weiter, statt zur Anmeldung umzuleiten
- Ein 401 wird nur wiederholt, wenn der Refresh ein neues Token geliefert hat
- Ereignisse auf `window` (ohne Tokens), Namen auch als Konstanten exportiert:
  - `AUTH_REFRESHED_EVENT` = `"idas-auth-refreshed"`, `detail: { expiresAt }` (ms) — nach jedem erfolgreichen Refresh/Login
  - `AUTH_EXPIRED_EVENT` = `"idas-auth-expired"`, `detail: { reason }` (`"refresh-rejected"`, `"no-refresh-token"`, `"identity-changed"`) — einmal je Ablauf und Auth-Manager, wenn die Sitzung nicht mehr erneuert werden kann

```js
window.addEventListener("idas-auth-expired", () => authManager.redirectToLogin());
```

### Wichtige Exporte
- `fetchEnvConfig(env)`
- `fluentIdasAuthManager(appToken, authBaseUrl)`
- `fluentApi(baseUrl, authManager, serviceName)`
- `idasFluentApi(baseUrl, authManager, serviceName)`
- `AUTH_REFRESHED_EVENT`, `AUTH_EXPIRED_EVENT`

### Wichtige Hinweise
- `idasFluentApi(...)` fuer IDAS-Business-Routinen verwenden
- `fluentApi(...)` fuer generische REST-Endpunkte verwenden
- `authManager.userInfo` und `idas.userInfo` enthalten dekodierte JWT-Claims
- Fuer JSDoc- und DTO-Typing-Regeln siehe [JSDOC.md](./JSDOC.md)

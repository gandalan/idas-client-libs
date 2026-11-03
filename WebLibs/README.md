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
- Ein 401 wird nur wiederholt, wenn der Refresh ein neues Token geliefert hat; das abgewiesene JWT wird dabei nur als ungueltig markiert (`invalidateToken`), nicht geleert
- Requests mit `auth=true` (Default) und Auth-Manager gehen nie ohne `Authorization`-Header raus. Ist kein brauchbares JWT zu bekommen, wirft der Request vor dem Senden einen `AuthError` (`code`, `sessionEnded`, `status`):
  - Sitzung beendet (`refresh-rejected`, `no-refresh-token`, `identity-changed`) oder gar keine Sitzung: `sessionEnded` (bei laufender Sitzung `true`, `AUTH_EXPIRED_EVENT` wurde ausgeloest), `status: 401`
  - voruebergehender Refresh-Fehler (Netzwerk, Timeout, 408/429, 5xx): `code: "refresh-failed"`, `status` des Refresh-Requests; ist das JWT nur im 30-s-Sicherheitsfenster und noch nicht wirklich abgelaufen, geht der Request stattdessen mit diesem JWT raus
  - Service-Tokens (`useToken` ohne Refresh-Token) gelten bis zu ihrem tatsaechlichen Ablauf
- Anonyme Endpunkte mit `auth=false` aufrufen (z. B. `api.get("Version", false)`); `idas.auth.authenticate`, `idas.auth.refreshToken` und `idas.benutzer.passwortReset` tun das selbst. `fluentApi(url, null, …)` ohne Auth-Manager sendet wie bisher ohne Token
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
- `RestError` (HTTP-Fehler einer gesendeten Anfrage), `AuthError` (Anfrage mangels Token nicht gesendet)

### Theme (`ui/theme`)
Zentrales Theme mit den Themes `neher`, `neher-dark` und `i3` als rohes CSS; gebaut wird im Zielprojekt.
- `neher-tokens.css`: reines CSS, nur Variablen (Farben, Schrift, Radien), ohne Tailwind und daisyUI nutzbar
- `neher-theme.css`: fuer Tailwind 4 + daisyUI 5, bindet die Tokens ein und ergaenzt den Feinschliff auf die daisyUI-Klassen; `tailwindcss` und `daisyui` bringt die App selbst mit

```css
@import "tailwindcss";
@import "@gandalan/weblibs/ui/theme/neher-theme.css";

/* optional: einzelne Variablen nach dem Import ueberschreiben */
[data-theme="neher"] { --color-primary: #5a9a1f; }
```

- Das Theme waehlt die App ueber `data-theme` (`neher`, `neher-dark`, `i3`); ohne Attribut gilt `neher`. In NeherApp3 setzt die Shell `data-theme` auch im Shadow DOM.
- Die ueberschreibbaren Variablen stehen im Kopf von `neher-tokens.css`.

### NeherApp3-Typen
Die Typen der NeherApp3-Host-API (`NeherApp3`, `NeherApp3Module`, `NeherMessage`, `NeherApp3I18n`, `NeherApp3Settings`, `NeherApp3Profile`, `NeherApp3Theme`, ...) stehen in `api/neherApp3Types.js` und sind ueber den Paket-Root importierbar:

```js
/** @type {import("@gandalan/weblibs").NeherApp3Module} */
export default { moduleName: "mein-modul", setup({ neherapp3 }) { /* ... */ } };
```

- Master ist NeherApp3 (`frontend/src/neherApp3Types.js`); die Datei hier ist eine Kopie und wird nicht von Hand bearbeitet
- Die NeherApp3-Pipeline (Stage `SyncWeblibsTypes`) uebernimmt Aenderungen automatisch per PR (Branch `neherapp3/host-api-types`)
- Die Beschreibungen erscheinen in `index.d.ts` als Doku-Kommentare
- Ausfuehrliche Doku zur Host-API: `docs/MODULE.md` in NeherApp3

### Wichtige Hinweise
- `idasFluentApi(...)` fuer IDAS-Business-Routinen verwenden
- `fluentApi(...)` fuer generische REST-Endpunkte verwenden
- `authManager.userInfo` und `idas.userInfo` enthalten dekodierte JWT-Claims
- Fuer JSDoc- und DTO-Typing-Regeln siehe [JSDOC.md](./JSDOC.md)

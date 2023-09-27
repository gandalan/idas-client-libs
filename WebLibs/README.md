# WebLibs for Gandalan JS/TS/Svelte projects

## IDAS API mit JavaScript/TypeScript verwenden

```js
import { IDASFactory } from '@gandalan/weblibs';
let idas = IDASFactory.create();
```

IDAS ab Version 1.0.0 verwendet JWT-Token für die Authentifizierung mit WebAPI.

Danach z.B. Zugriff auf die Mandant-Guid:

```js
let mandantGuid = await idas.then(i => i.mandantGuid);
```

Datenzugriffe erfolgen über die Objekte innerhalb der IDAS-Klasse

```js
let loader = Promise.all([
    idas.
      .then(i => i.mandanten.getAll())
      .then(d => mandanten = d.sort((a,b) => a.Name.localeCompare(b.Name)))
      .catch(e => error = e),
    idas
      .then(i => i.rollen.getAll())
      .then(d => rollen = d.sort((a,b) => a.Name.localeCompare(b.Name)))
      .catch(e => error = e)
])
      .then(_ => setMandant(mandantGuid));
```

der hier eingeführte `loader` kann mit dem `{#await}`-Svelte-Konstrukt verwendet werden:

```js
{#await loader}
    <progress />
{:then}
 ...
{/await}
```

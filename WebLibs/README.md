WebLibs for Gandalan JS/TS/Svelte projects

## IDAS API mit JavaScript/TypeScript verwenden


```js
import { IDAS } from '@gandalan/weblibs/api/IDAS';
let idas = new IDAS();

// bei Bedarf wird der Client zur Anmeldung umgeleitet, danach wird die aktuelle Seite wieder aufgerufen
idas.authenticateWithSSO(); 
```

Danach z.B. Zugriff auf die Mandant-Guid:

```js
let mandantGuid = idas.mandantGuid;
```

Datenzugriffe erfolgen über die Objekte innerhalb der IDAS-Klasse

```js
let loader = Promise.all([
	idas.mandanten.getAll()
		.then(d => mandanten = d.sort((a,b) => a.Name.localeCompare(b.Name)))
		.catch(e => error = e),
	idas.rollen.getAll()
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

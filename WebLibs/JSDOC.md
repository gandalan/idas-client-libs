# JSDoc Guide for WebLibs

This guide explains the small set of rules that keep IntelliSense working for consumers of `@gandalan/weblibs`.

Use it when you add:

- DTO properties
- API methods
- root function exports
- classes or other public types

If you follow the patterns below, consumers get stable types in both JS and TS.


## Goal

Public types must stay discoverable from:

- `import("@gandalan/weblibs").TypeName`
- `import { someFunction } from "@gandalan/weblibs"`
- generated `index.d.ts`

The package relies on JSDoc as the source of truth, and `npm run generate:dts` builds the root declaration output.


## The Short Version

1. Every pure-type JS file must be an ES module.
2. Always use `.js` in JSDoc import paths.
3. Import cross-file DTO types locally.
4. In API files, define short local typedef aliases at the top.
5. Avoid circular typing like `@returns {XApi}` together with `@typedef {ReturnType<typeof createXApi>} XApi`.
6. Regenerate declarations after public type changes.


## Basic Rules

### 1. Make type-only files real modules

If a file only contains typedefs, end it with:

```js
export {};
```

Without this, `import("./file.js").TypeName` can degrade to `any`.


### 2. Always include `.js` in import paths

Use:

```js
import("../dtos/belege.js").VorgangDTO
```

Not:

```js
import("../dtos/belege").VorgangDTO
```


### 3. Import cross-file property types where they are used

If a DTO property refers to a type from another file, add a local alias or use an inline import.

Preferred:

```js
/** @typedef {import('./kunden.js').KontaktDTO} KontaktDTO */

/**
 * @typedef {Object} VorgangDTO
 * @property {KontaktDTO} Kunde
 */

export {};
```

Also valid:

```js
/**
 * @typedef {Object} VorgangDTO
 * @property {import('./kunden.js').KontaktDTO} Kunde
 */

export {};
```


### 4. Keep API files readable with local aliases

At the top of each API file, create short aliases for the types used in that file.

```js
/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO
 */
```

Then use those aliases in `@param` and `@returns`.


## Common Tasks

### Add a property to an existing DTO

1. Open the concrete DTO owner file.
2. Add the property with the exact runtime type.
3. Import any cross-file type locally.
4. Ensure the file ends with `export {};` if it is type-only.

Example:

```js
/** @typedef {import('./kunden.js').BeleganschriftDTO} BeleganschriftDTO */

/**
 * @typedef {Object} BelegDTO
 * @property {string} BelegGuid
 * @property {BeleganschriftDTO} BelegAdresse
 * @property {number | null} Total
 */

export {};
```

Rules:

- Mark nullability explicitly.
- Match runtime names exactly.
- Mark optional properties only if they are actually optional.


### Add a function to a business API

Use this pattern:

```js
/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO
 */

/**
 * @param {FluentApi} fluentApi
 */
export function createProduktionApi(fluentApi) {
    return {
        /**
         * @returns {Promise<ProduktionsfreigabeItemDTO[]>}
         */
        getAllProduktionsfreigabeItems: () => fluentApi.get("ProduktionsfreigabeListe")
    };
}

/**
 * @typedef {ReturnType<typeof createProduktionApi>} ProduktionApi
 */
```

Important:

- Do not also write `@returns {ProduktionApi}` on `createProduktionApi`.
- The generator expands `ReturnType<typeof createXApi>` into the root `index.d.ts`.


### Add an optional API parameter

Document it exactly as the runtime behaves.

```js
/**
 * @param {boolean} [includeDetails=true]
 * @param {Date | null} [changedSince=null]
 * @returns {Promise<AblageDTO[]>}
 */
```

Use square brackets for optional parameters. Include default values when they exist.


### Add a root function export for consumers

If a function should be imported from the package root:

```js
import { fluentApi } from "@gandalan/weblibs";
```

then both of these must be true:

1. The function is exported from `index.js`.
2. The root declaration output includes a stable signature in `index.d.ts`.

In practice:

- add or keep the runtime export in `index.js`
- update the generator if the root declaration needs an explicit function signature
- run `npm run generate:dts`

Example consumer-facing signature:

```ts
export function fluentApi(url: string, authManager: FluentAuthManager | null, serviceName: string): FluentApi;
```

Rule of thumb:

- runtime export alone is not enough
- consumers need the root declaration too


### Add a public class for consumption

If you add a class that consumers should import directly:

```js
import { MyClient } from "@gandalan/weblibs";
```

follow this pattern:

```js
/**
 * Client for example operations.
 */
export class MyClient {
    /**
     * @param {string} baseUrl
     */
    constructor(baseUrl) {
        this.baseUrl = baseUrl;
    }

    /**
     * @param {string} id
     * @returns {Promise<string>}
     */
    async load(id) {
        return `${this.baseUrl}/${id}`;
    }
}
```

To make it consumable:

1. Export the class from its source file.
2. Re-export it from `index.js` if it belongs at the package root.
3. Run `npm run generate:dts`.
4. Verify the class shape appears in `index.d.ts`.

For helper-only local classes that are not part of the public API, do not expose them at the root.


### Add a new standalone public type

If you add a new manual type file such as `api/someTypes.js`, keep it simple:

```js
/**
 * @typedef {Object} ExampleOptions
 * @property {string} id
 * @property {boolean} [enabled=true]
 */

export {};
```

If that type must be visible to consumers, make sure the file is part of the generator input and regenerate declarations.


## Root Consumption Model

There are two public surfaces:

- `index.js` for runtime exports and root JSDoc aliases
- `index.d.ts` for consumer TypeScript declarations

`npm run generate:dts` updates both.

Do not hand-edit generated root blocks unless you are changing the generator itself.


## What to Prefer

Prefer:

```js
/** @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO */
```

Over:

```js
/**
 * @returns {Promise<import('../dtos/index.js').ProduktionsfreigabeItemDTO[]>}
 */
```

Prefer concrete DTO owner files over `dtos/index.js` when the owning file is known.


## What to Avoid

Avoid these patterns:

- extensionless JSDoc imports
- DTO files without `export {}`
- cross-file DTO references with no local import
- repeating deep inline imports in every method signature
- circular API return typing
- exposing a runtime export without making sure it is declared at the root


## Validation Workflow

When you change public JSDoc or exports:

1. Fix diagnostics in the file you changed.
2. Run `npm run generate:dts`.
3. Check that `index.js` and `index.d.ts` reflect the new public shape.
4. Verify IntelliSense from the package root.


## Quick Checklist

Before you finish, confirm:

- the file uses `.js` JSDoc imports
- type-only files end with `export {}`
- DTO property types are imported locally when needed
- public API methods use local aliases
- new root exports are present in both runtime and declarations
- `npm run generate:dts` has been run


## Bottom Line

If you want a property, function, or class to be easy for consumers to use, do three things:

1. Define the type clearly in the owning file.
2. Export it through the correct public surface.
3. Regenerate the root declarations.

That is the whole system.